using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.SignalR;

[assembly: OwinStartup(typeof(dadagarjo.Startup))]

namespace dadagarjo
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
            GlobalHost.Configuration.MaxIncomingWebSocketMessageSize = 1024 * 1000;
        }
    }
}
