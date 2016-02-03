using StartUpMentor.Common.Filters;
using StartUpMentor.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartUpMentor.Service.Common
{
    public interface IAnswerService
    {
        Task<IAnswer> GetAsync(Guid id);
        Task<IEnumerable<IAnswer>> GetRangeAsync(Guid questionId, GenericFilter filter);
        Task<int> AddAsync(IAnswer answer);
        Task<int> UpdateAsync(IAnswer answer);
        Task<int> DeleteAsync(Guid id);
    }
}
