using StartUpMentor.DAL;
using StartUpMentor.Repository.Common.IGenericRepository;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace StartUpMentor.Repository.GenericRepository
{
	public class UnitOfWork : IUnitOfWork
    {
        protected IApplicationDbContext Context { get; private set; }

        public UnitOfWork(IApplicationDbContext context)
        {
            if (context == null) throw new ArgumentNullException("Context is null");

            Context = context;
        }

        public Task<T> AddAsync<T>(T entity) where T : class
        {
            try
            {
                DbEntityEntry dbEntity = Context.Entry(entity);
                if (dbEntity.State != EntityState.Detached)
                    dbEntity.State = EntityState.Added;
                else
                    Context.Set<T>().Add(entity);

                return Task.FromResult(dbEntity.Entity as T);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Task<T> UpdateWithAddAsync<T>(T entity) where T : class
        {
            try
            {
                DbEntityEntry entry = Context.Entry<T>(entity);
                Context.Set<T>().Add(entity);
                entry.State = EntityState.Modified;

                return Task.FromResult<T>(entry as T);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<T> UpdateWithAddAsync<T>(T entity, params System.Linq.Expressions.Expression<Func<T, object>>[] entityParameters) where T : class
        {
            try
            {
                DbEntityEntry entry = Context.Entry<T>(entity);
                Context.Set<T>().Add(entity);
                entry.State = EntityState.Modified;
                foreach (var p in entityParameters)
                {
                    Context.Entry<T>(entity).Property(p).IsModified = true;
                }

                return Task.FromResult<T>(entry as T);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<T> UpdateAsync<T>(T entity) where T : class
        {
            try
            {
                DbEntityEntry entry = Context.Entry(entity);
                entry.State = EntityState.Modified;

                return Task.FromResult(entry.Entity as T);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<int> DeleteAsync<T>(T entity) where T : class
        {
            try
            {
                DbEntityEntry entry = Context.Entry(entity);
                if (entry.State != EntityState.Deleted)
                    entry.State = EntityState.Deleted;

                return Task.FromResult(1);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<int> DeleteAsync<T>(Guid id) where T : class
        {
            try
            {
                T entity = Context.Set<T>().Find(id);
                if (entity == null)
                    return Task.FromResult(0);

                return DeleteAsync<T>(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<int> DeleteAsync<T>(System.Linq.Expressions.Expression<Func<T, bool>> match) where T : class
        {

            try
            {
                T entity = Context.Set<T>().Where(match).First();
                if (entity == null)
                    return Task.FromResult(0);

                return DeleteAsync<T>(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> CommitAsync()
        {
            return await Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Context.Dispose();
        }


        
    }
}
