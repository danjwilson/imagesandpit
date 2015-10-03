using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ImageSandpit.Startup))]
namespace ImageSandpit
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
