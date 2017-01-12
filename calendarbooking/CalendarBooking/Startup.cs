using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CalendarBooking.Startup))]
namespace CalendarBooking
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
