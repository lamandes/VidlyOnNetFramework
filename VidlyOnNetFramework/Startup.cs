using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VidlyOnNetFramework.Startup))]
namespace VidlyOnNetFramework
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
