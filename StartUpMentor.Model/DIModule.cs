using Ninject.Extensions.Factory;
using StartUpMentor.Model.Common;

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

			Bind<IUserIdentity>().To<UserIdentity>();
			Bind<IUserPrincipal>().To<UserPrincipal>();
			Bind<ISecurityEntity>().To<SecurityEntity>();
			Bind<ISecurityCookie>().To<SecurityCookie>();
			Bind<ISecurityFactory>().ToFactory();

			/*
					 //Za roles
					 Bind<IRoleStore<IdentityRole, string>>().To<RoleStore<IdentityRole>>();
					 Bind<RoleManager<IdentityRole>>().ToSelf();

					 //Za usera
					 Bind(typeof(IUserStore<ApplicationUser>)).To(typeof(UserStore<ApplicationUser>));
					 Bind(typeof(UserManager<ApplicationUser>)).ToSelf();
					 Bind(typeof(DbContext)).To(typeof(ApplicationDbContext));
			 */
		}
    }
}
