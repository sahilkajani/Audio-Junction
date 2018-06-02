using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Audio_Junction.Startup))]
namespace Audio_Junction
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
