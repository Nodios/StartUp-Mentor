using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartUpMentor.Model.Common
{
	public interface ISecurityEntity
	{
		Guid UserId { get; set; }
		string tokenHash { get; set; }
		DateTime expiryDate { get; set; }
	}

	public interface ISecurityCookie
	{
		string UserName { get; set; }
		string token { get; set; }
	}

	public interface IUserIdentity : System.Security.Principal.IIdentity
	{

    }

	public interface IUserPrincipal : System.Security.Principal.IPrincipal
	{
		ICollection<string> Roles { get; set; }
	}

	public interface ISecurityFactory
	{
		IUserIdentity CreateIdentity();
		IUserIdentity CreateIdentity(string Name, bool IsAuthenticated, string AuthenticationType, ICollection<string> roles);
		IUserPrincipal CreatePrincipal();
		IUserPrincipal CreatePrincipal(IUserIdentity identity);
		ISecurityEntity CreateEntity();
		ISecurityCookie CreateCookie();
	}
}
