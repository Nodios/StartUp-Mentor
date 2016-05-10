using StartUpMentor.Service.Common;
using System;
using System.Web;
using System.Threading.Tasks;
using StartUpMentor.Model.Common;

namespace StartUpMentor.UI
{
	class IdentityModule : IHttpModule
	{

		protected IUserService UserService { get; set; }
		protected ISecurityService SecurityService { get; set; }
		protected ISecurityFactory SecurityFactory { get; set; }

		public IdentityModule(IUserService UserService, ISecurityService SecurityService, ISecurityFactory SecurityFactory)
		{
			this.UserService = UserService;
			this.SecurityService = SecurityService;
			this.SecurityFactory = SecurityFactory;
		}

		public void Dispose() { }

		public string ModuleName { get { return "IdentityModule"; } }

		public void Init(HttpApplication context)
		{
			context.AuthenticateRequest += (new EventHandler(this.AuthenticateUser));
		}

		private void AuthenticateUser(Object source, EventArgs e)
		{
			var cookie = System.Web.HttpContext.Current.Request.Cookies["identity"];
			IUserPrincipal userPrincipal;

			if (cookie != null && cookie.Value != null)
			{
				userPrincipal = Task.Run(async () => { return await SecurityService.Authenticate(cookie.Value); }).Result;
			}
			else
			{
				userPrincipal = SecurityFactory.CreatePrincipal();
			}

			HttpContext.Current.User = userPrincipal;

			return;
		}
	}

	public class AuthorizeAttribute : System.Web.Mvc.AuthorizeAttribute
	{
		public AuthorizeAttribute() : base() { }

		protected new virtual bool AuthorizeCore(HttpContextBase httpContext)
		{
			var user = httpContext.User;
			
			if(!user.Identity.IsAuthenticated)
			{
				return false;
			}

			if (base.Roles != "")
			{
				var roles = base.Roles.Split(',');
				foreach (var role in roles)
				{
					if(!user.IsInRole(role))
					{
						return false;
					}
				}
			}
			return true;
		}

		protected new void HandleUnauthorizedRequest(System.Web.Mvc.AuthorizationContext filterContext)
		{
			HttpContext.Current.Response.Redirect("/user/login", true);
			HttpContext.Current.Response.End();
			return;
		}

		public override void OnAuthorization(System.Web.Mvc.AuthorizationContext filterContext)
		{
			if( AuthorizeCore(filterContext.HttpContext))
			{
				return;
			}
			HandleUnauthorizedRequest(filterContext);
		}

		protected new HttpValidationStatus OnCacheAuthorization(HttpContextBase httpContext)
		{
			return new HttpValidationStatus();
		}
	}
}
