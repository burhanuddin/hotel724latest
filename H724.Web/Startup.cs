using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(H724.Web.Startup))]
namespace H724.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
