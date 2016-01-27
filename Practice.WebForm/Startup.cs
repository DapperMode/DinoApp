using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Practice.WebForm.Startup))]
namespace Practice.WebForm
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
