using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Mauka.Web.Startup))]
namespace Mauka.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
