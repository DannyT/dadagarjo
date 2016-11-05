using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using dadagarjo.Models;

namespace dadagarjo
{
    public class RoomHub : Hub
    {

        public void RoomChoice(Room room)
        {
            Clients.All.SetRoom(room);
        }

        public void Hello()
        {
            Clients.All.hello("woop");
        }
    }
}