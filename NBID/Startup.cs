using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NBID.Startup))]
namespace NBID
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
