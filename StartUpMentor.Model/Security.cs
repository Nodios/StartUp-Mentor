using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StartUpMentor.Model.Common;
using System.Security.Principal;

namespace StartUpMentor.Model
{
	public class SecurityEntity : ISecurityEntity
	{
		public Guid UserId { get; set; }
		public string tokenHash { get; set; }
		public DateTime expiryDate { get; set; }
	}

	public class SecurityCookie : ISecurityCookie
	{
		public string UserName { get; set; }
		public string token { get; set; }
	}

	public class UserPrincipal : IUserPrincipal
	{
		public IIdentity Identity { get; set; }
		public ICollection<string> Roles { get; set; }

		public UserPrincipal(IIdentity Identity, ICollection<string> Roles)
		{
			this.Identity = Identity;
			this.Roles = Roles;
		}

		public UserPrincipal()
		{
			this.Identity = new UserIdentity();
		}

		public UserPrincipal(IUserIdentity identity)
		{
			this.Identity = identity;
		}

		public bool IsInRole(string role)
		{
			if(Roles.Contains(role))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}

	public class UserIdentity : IUserIdentity
	{
		public UserIdentity() {}

		public UserIdentity(string Name, bool IsAuthenticated, string AuthenticationType, ICollection<string> roles) 
		{
			this.Name = Name;
			this.IsAuthenticated = IsAuthenticated;
			this.AuthenticationType = AuthenticationType;
		}

		public string AuthenticationType { get; private set; }

		public bool IsAuthenticated { get; private set; }

		public string Name { get;  private set; }
	}
}
