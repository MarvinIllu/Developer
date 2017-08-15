using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ControlPagosInbaco.Startup))]
namespace ControlPagosInbaco
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
