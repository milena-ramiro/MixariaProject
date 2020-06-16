using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EconomizeMais.Startup))]
namespace EconomizeMais
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
