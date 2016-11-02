using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GorenjeDashboard.Startup))]
namespace GorenjeDashboard
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
