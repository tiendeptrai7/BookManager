using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(btWEB2.Startup))]
namespace btWEB2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
