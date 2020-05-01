using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AppartmentRentalFinalProject.Startup))]
namespace AppartmentRentalFinalProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
