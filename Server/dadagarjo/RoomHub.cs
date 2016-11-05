using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace dadagarjo
{
    public class RoomHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello("woop");
        }
    }
}