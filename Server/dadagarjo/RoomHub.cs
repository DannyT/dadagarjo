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

        public void SetRoomOptions(Room room1, string room1image, Room room2, string room2image)
        {
            Clients.Others.ShowRoomOptions(room1, room1image, room2, room2image);
        }
    }
}