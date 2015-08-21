using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Homework31.WebApp.Startup))]
namespace Homework31.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
