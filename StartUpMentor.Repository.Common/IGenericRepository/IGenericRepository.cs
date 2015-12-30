using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StartUpMentor.Repository.Common.IGenericRepository
{
    public interface IGenericRepository
    {
        IUnitOfWork CreateUnitOfWork();

        Task<T> GetAsync<T>(Guid id) where T : class;
        IQueryable<T> GetWhere<T>() where T : class;

        Task<T> GetAsync<T>(Expression<Func<T, bool>> match) where T : class;
        Task<IEnumerable<T>> GetRangeAsync<T>(Expression<Func<T, bool>> match) where T : class;
        Task<IEnumerable<T>> GetRangeAsync<T>() where T : class;

        Task<int> AddAsync<T>(T entity) where T : class;
        Task<int> UpdateAsync<T>(T entity) where T : class;
        Task<int> DeleteAsync<T>(T entity) where T : class;
        Task<int> DeleteAsync<T>(Guid id) where T : class;

    }
}
