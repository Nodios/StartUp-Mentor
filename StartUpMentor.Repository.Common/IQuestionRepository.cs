using StartUpMentor.Common.Filters;
using StartUpMentor.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartUpMentor.Repository.Common
{
    public interface IQuestionRepository
    {
        /// <summary>
        /// Get question by id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>single question with maching id</returns>
        Task<IQuestion> GetAsync(Guid id);
        /// <summary>
        /// Get all questions from one field with maching id
        /// </summary>
        /// <param name="fieldId">field id</param>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<IEnumerable<IQuestion>> GetRangeAsync(Guid fieldId, GenericFilter filter);

        Task<int> AddAsync(IQuestion question);
        Task<int> UpdateAsync(IQuestion question);
        Task<int> DeleteAsync(IQuestion question);
        Task<int> DeleteAsync(Guid id);
    }
}
