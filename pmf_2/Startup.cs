using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(pmf_2.Startup))]
namespace pmf_2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
