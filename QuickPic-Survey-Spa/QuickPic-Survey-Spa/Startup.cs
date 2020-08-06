using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QuickPic_Survey_Spa.Startup))]
namespace QuickPic_Survey_Spa
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
           
        }

     
    }
}
