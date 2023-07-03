using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Mouka.Web.Startup))]
namespace Mouka.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
