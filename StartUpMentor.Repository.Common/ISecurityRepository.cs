using System;
using System.Threading.Tasks;
using StartUpMentor.Model.Common;

namespace StartUpMentor.Repository.Common
{
	public interface ISecurityRepository
	{
		Task<ISecurityEntity> Get(Guid UserId, string tokenHash);
		Task<bool> AddToken(ISecurityEntity token);
		Task<bool> RemoveToken(Guid UserId, string tokenHash);
    }
}
