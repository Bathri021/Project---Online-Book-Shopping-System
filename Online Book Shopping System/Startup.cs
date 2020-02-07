using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Online_Book_Shopping_System.Startup))]
namespace Online_Book_Shopping_System
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
