using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StartUpMentor.Model.Common;

namespace StartUpMentor.Service.Common
{
	public interface ISecurityService
	{
		Task<ISecurityEntity> CreateTokenAsync(IUser user, string token);
		Task<ISecurityEntity> CreateTokenAsync(Guid UserId, string token);

		Task<ISecurityCookie> CreateTokenCookie(IUser user);
		Task<ISecurityCookie> CreateTokenCookie(string username);

        Task<bool> RemoveTokenAsync(ISecurityEntity token);
		Task<bool> RemoveTokenAsync(Guid UserId, string tokenHash);
		Task<bool> RemoveTokenAsync(string token);

		Task<IUserPrincipal> Authenticate(string token);
		Task<IUserPrincipal> Authenticate(Guid userId, string UserName, string tokenHash);

        Task<IUserIdentity> GetIdentity(IUser user, bool isAuthenticated);
		Task<IUserPrincipal> GetPrincipal(IUserIdentity identity);

        Task<ISecurityCookie> DeserializeToken(string token);
		Task<string> SerializeCookie(ISecurityCookie token);
	}
}
