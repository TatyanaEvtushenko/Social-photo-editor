using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SocialPhotoEditor.Startup))]
namespace SocialPhotoEditor
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
