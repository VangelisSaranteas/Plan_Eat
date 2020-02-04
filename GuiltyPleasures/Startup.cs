using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GuiltyPleasures.Startup))]
namespace GuiltyPleasures
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
