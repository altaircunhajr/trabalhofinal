using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(trabalhofinal.Startup))]
namespace trabalhofinal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
