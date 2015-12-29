using StartUpMentor.DAL;
using StartUpMentor.Repository.Common.IGenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace StartUpMentor.Repository.GenericRepository
{
    public class GenericRepository : IGenericRepository
    {
        #region Fields
        protected IApplicationDbContext Context { get; private set; }
        protected IUnitOfWorkFactory UnitOfWorkFactory { get; private set; }
        #endregion

        #region Constructor
        public GenericRepository(IApplicationDbContext context, IUnitOfWorkFactory unitOfWorkFactory)
        {
            Context = context;
            UnitOfWorkFactory = unitOfWorkFactory;
        }
        #endregion

        public IUnitOfWork CreateUnitOfWork()
        {
            return UnitOfWorkFactory.CreateUnitOfWork();
        }

        public Task<T> GetAsync<T>(Guid id) where T : class
        {
            return Context.Set<T>().FindAsync(id);
        }

        public IQueryable<T> GetWhere<T>() where T : class
        {
            return Context.Set<T>();
        }

        public async Task<T> GetAsync<T>(Expression<Func<T, bool>> match) where T : class
        {
            return await Context.Set<T>().FirstAsync(match);
        }

        public async Task<IEnumerable<T>> GetAsync<T>(Expression<Func<T, bool>> match) where T : class
        {
            return await Context.Set<T>().Where(match).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAsync<T>() where T : class
        {
            return await Context.Set<T>().ToListAsync();
        }

        #region Add/Update/Delete
        public async Task<int> AddAsync<T>(T entity) where T : class
        {
            try
            {
                DbEntityEntry entry = Context.Entry(entity);
                if (entry.State != EntityState.Detached)
                    entry.State = EntityState.Added;
                else
                    Context.Set<T>().Add(entity);

                return await Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> UpdateAsync<T>(T entity) where T : class
        {
            DbEntityEntry entry = Context.Entry(entity);
            if (entry.State == EntityState.Detached)
                Context.Set<T>().Attach(entity); //.Detached - the entity is not being tracked by the context: https://msdn.microsoft.com/en-us/data/jj592676.aspx
            
            entry.State = EntityState.Modified; //The entity is being tracked by the context and exists in the database, and some or all of its property values have been modified

            try
            {
                return await Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> DeleteAsync<T>(T entity) where T : class
        {
            try
            {
                Context.Set<T>().Remove(entity);
                return await Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> DeleteAsync<T>(Guid id) where T : class
        {
            T entity = await GetAsync<T>(id); //Fetch entity with id
            if (entity == null)
                throw new ArgumentNullException("Entity is null, does not exist");

            return await DeleteAsync<T>(entity); //Call DeleteAsync<T>(T entity) method and delete entity with id id
        }
        #endregion
    }
}
