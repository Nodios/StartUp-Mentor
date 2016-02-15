using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using StartUpMentor.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using StartUpMentor.DAL.Models;
using StartUpMentor.UI.Models;
using StartUpMentor.UI.Models.User;

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

                bool result = await Service.RegisterUser(AutoMapper.Mapper.Map<Model.ApplicationUser>(user), model.Password);

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
            }
        }
    }
}