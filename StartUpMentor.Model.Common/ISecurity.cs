using System;
using System.Collections.Generic;

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
		Guid userId
		{
			get;
		}
    }

	public interface IUserPrincipal : System.Security.Principal.IPrincipal
	{
		ICollection<string> Roles { get; set; }

	}

	public interface ISecurityFactory
	{
		IUserIdentity CreateIdentity();
		IUserIdentity CreateIdentity(string Name, Guid userId, bool IsAuthenticated, string AuthenticationType, ICollection<string> roles);
		IUserPrincipal CreatePrincipal();
		IUserPrincipal CreatePrincipal(IUserIdentity identity);
		ISecurityEntity CreateEntity();
		ISecurityCookie CreateCookie();
	}
}
