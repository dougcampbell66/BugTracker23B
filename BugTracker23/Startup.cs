using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BugTracker23.Startup))]
namespace BugTracker23
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
