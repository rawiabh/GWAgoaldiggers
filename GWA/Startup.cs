using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GWA.Startup))]
namespace GWA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
