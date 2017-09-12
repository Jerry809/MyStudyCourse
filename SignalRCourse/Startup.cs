using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SignalRCourse.Startup))]
namespace SignalRCourse
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
