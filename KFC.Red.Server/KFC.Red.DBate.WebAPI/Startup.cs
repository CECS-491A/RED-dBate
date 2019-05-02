using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;

[assembly: OwinStartup(typeof(KFC.Red.DBate.WebAPI.Startup))]

namespace KFC.Red.DBate.WebAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            //ConfigureAuth(app);

            app.UseCors(CorsOptions.AllowAll);
            //var hubConfiguration = new HubConfiguration();
            //hubConfiguration.EnableDetailedErrors = true;
            //app.MapSignalR(hubConfiguration);
            app.MapSignalR();
        }
    }
}
