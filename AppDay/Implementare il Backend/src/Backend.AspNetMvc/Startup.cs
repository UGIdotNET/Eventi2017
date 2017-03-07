using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Backend.AspNetMvc.Startup))]
namespace Backend.AspNetMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
