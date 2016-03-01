/*
using StartUpMentor.UI.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace StartUpMentor.UI.Controllers
{
	public class RoleController : Controller
    {
        public RoleManager<IdentityRole> RoleManager { get; private set; }

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            RoleManager = roleManager;
        }

        // GET: Role
        public ActionResult Index()
        {
            //Get all roles from database
            return View(RoleManager.Roles);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RoleViewModel roleViewModel)
        {
            if (ModelState.IsValid)
            {
                var role = new IdentityRole(roleViewModel.Name);
                var roleResult = await RoleManager.CreateAsync(role);
                if (!roleResult.Succeeded)
                {
                    ModelState.AddModelError("", roleResult.Errors.First().ToString());
                    return View();
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        //TODO: Add edit and delete for Roles
    }
}
*/