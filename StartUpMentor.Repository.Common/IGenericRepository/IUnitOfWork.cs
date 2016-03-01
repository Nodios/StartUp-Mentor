using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StartUpMentor.Repository.Common.IGenericRepository
{
	public interface IUnitOfWork : IDisposable
    {
        Task<T> AddAsync<T>(T entity) where T : class;
        Task<T> UpdateAsync<T>(T entity) where T : class;
        Task<T> UpdateWithAddAsync<T>(T entity) where T : class;
        Task<T> UpdateWithAddAsync<T>(T entity, params Expression<Func<T, object>>[] entityParameters) where T : class;

        Task<int> DeleteAsync<T>(T entity) where T : class;
        Task<int> DeleteAsync<T>(Guid id) where T : class;
        Task<int> DeleteAsync<T>(Expression<Func<T, bool>> match) where T : class;
        Task<int> CommitAsync();

    }
}
