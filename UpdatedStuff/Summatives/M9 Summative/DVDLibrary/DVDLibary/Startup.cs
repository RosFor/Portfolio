using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DVDLibary.Startup))]
namespace DVDLibary
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
