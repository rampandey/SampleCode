using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SampleCode.Startup))]
namespace SampleCode
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
