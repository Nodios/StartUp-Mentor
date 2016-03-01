using StartUpMentor.Service.Common;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Data.Entity;
using StartUpMentor.DAL.Models;
using StartUpMentor.UI.Models;
using System.Web;
using StartUpMentor.Model.Common;

namespace StartUpMentor.UI.Controllers
{
	public class UserController : Controller
	{
		protected IUserService Service { get; private set; }
		protected ISecurityService SecurityService { get; private set; }

		public UserController(IUserService Service, ISecurityService SecurityService)
		{
			this.Service = Service;
			this.SecurityService = SecurityService;
		}

		public ActionResult Index()
		{
			return View();
		}

		public ActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public async Task<ActionResult> Register(StartUpMentor.UI.Models.RegisterViewModel viewModel)
		{
			if (!ModelState.IsValid)
			{
				return View(viewModel);
			}

			var userModel = AutoMapper.Mapper.Map<IUser>(viewModel);

			await Service.RegisterUser(userModel, viewModel.Password);

			HttpCookie cookie = new HttpCookie("identity");
			var tokenCookie = await SecurityService.CreateTokenCookie(userModel);

			var token = await SecurityService.CreateTokenAsync(userModel.Id, tokenCookie.token);

			cookie.Value = await SecurityService.SerializeCookie(tokenCookie);
			Response.SetCookie(cookie);

			var userPrincipal = await SecurityService.Authenticate(cookie.Value);
			HttpContext.User = userPrincipal;

			return View("Index");
		}

		public ActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public async Task<ActionResult> Login(StartUpMentor.UI.Models.LoginViewModel viewModel)
		{
			if (!ModelState.IsValid)
			{
				return View(viewModel);
			}

			var user = await Service.FindAsync(viewModel.Email, viewModel.Password);
			if(user != null)
			{
				HttpCookie cookies = new HttpCookie("identity");

				var tokenCookie = await SecurityService.CreateTokenCookie(user);
				var tokenEntity = await SecurityService.CreateTokenAsync(user.Id, tokenCookie.token);
				cookies.Value = await SecurityService.SerializeCookie(tokenCookie);

				var userPrincipal = await SecurityService.Authenticate(user.Id, user.UserName, tokenEntity.tokenHash);

				HttpContext.User = userPrincipal;

				Response.SetCookie(cookies);
			}
			
			return View(viewModel);
		}

		[HttpPost]
		public async Task<ActionResult> LogOff()
		{
			var cookies = Request.Cookies["identity"];
			if (cookies != null && cookies.Value != null)
			{
				cookies.Expires = DateTime.Now.AddDays(-1);
				var remove = await SecurityService.RemoveTokenAsync(cookies.Value);

				if(remove)
				{
					Response.Cookies.Set(cookies);
					HttpContext.User = await SecurityService.GetPrincipal(null);
				}
			}

			return View("Index");
		}
	}

}

/*
using StartUpMentor.Service.Common;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Data.Entity;
using StartUpMentor.DAL.Models;
using StartUpMentor.UI.Models;

namespace StartUpMentor.UI.Controllers
{
	public class UserController : Controller
    {
        protected IUserService Service { get; private set; }
        protected IFieldService FieldService { get; private set; }
        public RoleManager<IdentityRole> RoleManager { get; private set; }
        protected UserManager<ApplicationUser> UserManager { get; private set; }

        public UserController(IUserService service, RoleManager<IdentityRole> roleManager)
        {
            Service = service;
            RoleManager = roleManager;
            UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new StartUpMentor.DAL.ApplicationDbContext()));
        }

        // GET: User
        public async Task<ActionResult> Index(ApplicationUser user, int? id)
        {
            try
            {
                //Get all users from database
                return View(await UserManager.Users.ToListAsync());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult Register()
        {
            ////Get all fields for display in view
            //ViewBag.Field = await FieldService.GetRangeAsync(null);

            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model, UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                user.Info = new InfoViewModel { FirstName = model.FirstName, LastName = model.LastName, Contact = model.Contact, Email = model.Email };

                bool result = await Service.RegisterUser(AutoMapper.Mapper.Map<Model.Common.IUser>(user), model.Password);

                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
*/
