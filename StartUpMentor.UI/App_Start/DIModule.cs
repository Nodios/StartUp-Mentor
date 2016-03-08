using System.Web;

namespace StartUpMentor.UI
{
	public class DIModule : Ninject.Modules.NinjectModule
	{
		public override void Load()
		{
			Bind<IHttpModule>().To<IdentityModule>();
		}
	}
}
