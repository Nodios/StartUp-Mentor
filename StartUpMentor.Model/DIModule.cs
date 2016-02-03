using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using StartUpMentor.DAL;
using StartUpMentor.Model.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartUpMentor.Model
{
    public class DIModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {

            Bind<IAnswer>().To<Answer>();
            Bind<IField>().To<Field>();
            Bind<IInfo>().To<Info>();
            Bind<IQuestion>().To<Question>();

            //Za roles
            Bind<IRoleStore<IdentityRole, string>>().To<RoleStore<IdentityRole>>();
            Bind<RoleManager<IdentityRole>>().ToSelf();

            //Za usera
            Bind(typeof(IUserStore<ApplicationUser>)).To(typeof(UserStore<ApplicationUser>));
            Bind(typeof(UserManager<ApplicationUser>)).ToSelf();
            Bind(typeof(DbContext)).To(typeof(ApplicationDbContext));
        }
    }
}
