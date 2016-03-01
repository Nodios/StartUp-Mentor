using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StartUpMentor.UI.Startup))]
namespace StartUpMentor.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
			
        }
    }
}
