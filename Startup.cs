using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(cxp.Startup))]
namespace cxp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
