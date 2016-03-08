using StartUpMentor.Service.Common;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
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

		public async Task<ActionResult> Index()
		{
			var users = await Service.GetAllUsers();
			return View(users);
		}

		public ActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public async Task<ActionResult> Register(StartUpMentor.UI.Models.RegisterViewModel viewModel)
		{
			if(! await SecurityService.VerifyPassword(viewModel.Password))
			{ 
				ModelState.AddModelError("Password", "Password must contain one lowercase letter, one uppercase letter, one number and one special character (!#$%&@*?==");
            }

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

		public ActionResult Manage()
		{
			var model = new StartUpMentor.UI.Models.User.IndexViewModel();
			model.HasPassword = true;

            return View(model);
		}

		[HttpPost]
		public ActionResult AddRole()
		{
			return View("Manage");
		}

		[HttpPost]
		public ActionResult RemoveRole()
		{
			return View("Manage");
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
<<<<<<< HEAD
using StartUpMentor.UI.Models.User;
=======
>>>>>>> c2ed2912f8c20e58d04b3078661002db0eb318f4

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

<<<<<<< HEAD
        public ActionResult Register()
        {
            ////Get all fields for display in view
            //ViewBag.Field = await FieldService.GetRangeAsync(null);

=======
        public async Task<ActionResult> Register()
        {
            //Get all fields for display in view
            ViewBag.Field = await FieldService.GetRangeAsync(null);
            //Get all roles
            ViewBag.Roles = await RoleManager.Roles.ToListAsync();
>>>>>>> c2ed2912f8c20e58d04b3078661002db0eb318f4

            return View();
        }
        [HttpPost]
<<<<<<< HEAD
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model, UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                user.Info = new InfoViewModel { FirstName = model.FirstName, LastName = model.LastName, Contact = model.Contact, Email = model.Email };

<<<<<<< HEAD
                bool result = await Service.RegisterUser(AutoMapper.Mapper.Map<Model.Common.IUser>(user), model.Password);
=======
                bool result = await Service.RegisterUser(AutoMapper.Mapper.Map<Model.ApplicationUser>(user), model.Password);
>>>>>>> remotes/origin/video

                return RedirectToAction("Index");
            }
            return View(model);
        }

        //TODO: ŠTA OVDJE?!
        private void PopulateUserFieldData(IUser user)
        {
            var fields = FieldService.GetRangeAsync(null).Result;
            var viewModel = new List<UserFieldData>();
            foreach(var field in fields)
            {
                viewModel.Add(new UserFieldData
                {
                    FieldId = field.Id,
                    Name = field.Name
                    //treba dodati checked
                });
=======
        public async Task<ActionResult> Register(RegisterViewModel model, UserViewModel user, string roleId)
        {
            if (ModelState.IsValid)
            {
                user.Info = new InfoViewModel { FirstName = model.FirstName, LastName = model.LastName, Contact = model.Contact };

                bool adminResult = await Service.RegisterUser(AutoMapper.Mapper.Map<Model.Common.IApplicationUser>(user), model.Password);

                if (adminResult)
                {
                    if (!String.IsNullOrEmpty(roleId))
                    {
                        var role = await RoleManager.FindByIdAsync(roleId);
                        var result = await UserManager.AddToRoleAsync(user.Id, role.Name);
                        if (!result.Succeeded)
                        {
                            ModelState.AddModelError("", result.Errors.First().ToString());
                            //Get all fields for display in view
                            ViewBag.Field = await FieldService.GetRangeAsync(null);
                            //Get all roles
                            ViewBag.Roles = await RoleManager.Roles.ToListAsync();
                            return View();
                        }
                    }
                }
                else
                {
                    //Get all fields for display in view
                    ViewBag.Field = await FieldService.GetRangeAsync(null);
                    //Get all roles
                    ViewBag.Roles = await RoleManager.Roles.ToListAsync();
                    return View();
                }
                return RedirectToAction("Index");
            }
            else
            {
                //Get all fields for display in view
                ViewBag.Field = await FieldService.GetRangeAsync(null);
                //Get all roles
                ViewBag.Roles = await RoleManager.Roles.ToListAsync();
                return View();
>>>>>>> c2ed2912f8c20e58d04b3078661002db0eb318f4
            }
        }
    }
}
*/
