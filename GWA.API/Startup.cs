using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GWA.API.Startup))]
namespace GWA.API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
