using StartUpMentor.Model.Common;
using System;
using System.Threading.Tasks;

namespace StartUpMentor.Repository.Common
{
	public interface IInfoRepository
    {
        Task<IInfo> GetAsync(Guid id);
        Task<int> AddAsync(IInfo info);
        Task<int> UpdateAsync(IInfo info);
        Task<int> DeleteAsync(IInfo info);
        Task<int> DeleteAsync(Guid id);
    }
}
