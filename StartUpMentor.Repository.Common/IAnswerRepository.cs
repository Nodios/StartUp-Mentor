using StartUpMentor.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StartUpMentor.Common;
using StartUpMentor.Common.Filters;

namespace StartUpMentor.Repository.Common
{
    public interface IAnswerRepository
    {
        /// <summary>
        /// Get by id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>single answer</returns>
        Task<IAnswer> GetAsync(Guid id);
        /// <summary>
        /// Get all
        /// </summary>
        /// <param name="filter">filter for paging, sorting and filtering</param>
        /// <returns>List</returns>
        Task<IEnumerable<IAnswer>> GetAsync(GenericFilter filter);
        /// <summary>
        /// Get answers from question
        /// </summary>
        /// <param name="questionId">question id</param>
        /// <param name="filter">filter for paging, sorting and filtering</param>
        /// <returns>list of answers from question with id id</returns>
        Task<IEnumerable<IAnswer>> GetRangeAsync(Guid questionId, GenericFilter filter);

        Task<int> AddAsync(IAnswer answer);
        Task<int> UpdateAsync(IAnswer answer);
        Task<int> DeleteAsync(IAnswer answer);
        Task<int> DeleteAsync(Guid id);
    }
}
