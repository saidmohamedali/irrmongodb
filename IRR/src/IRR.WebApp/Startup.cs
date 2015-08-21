using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IRRCalulation.WebApp.Startup))]
namespace IRRCalulation.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
