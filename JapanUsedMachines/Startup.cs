using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JapanUsedMachines.Startup))]
namespace JapanUsedMachines
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
