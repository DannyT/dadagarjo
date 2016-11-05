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
        private static Dictionary<Room, int> _rooms;
        private static Dictionary<string, string> _voters;

        public void RoomChoice(Room room)
        {
            Clients.All.SetRoom(room);
        }

        public void SetRoomOptions(Room room1, string room1image, Room room2, string room2image)
        {
            _rooms = new Dictionary<Room, int>();
            _voters = new Dictionary<string, string>();
            _rooms.Add(room1, 0);
            _rooms.Add(room2, 0);

            Clients.Others.ShowRoomOptions(room1, room1image, room2, room2image);
        }

        public void VoteForRoom(string roomName)
        {
            if (_rooms == null)
                _rooms = new Dictionary<Room, int>();

            if (!_rooms.Keys.Any(x=> x.RoomName == roomName))
                return;

            var roomVote = _rooms.Where(x => x.Key.RoomName.ToLower() == roomName.ToLower()).First();

            if (_voters == null)
                _voters = new Dictionary<string, string>();

            var clientName = Context.User.Identity.Name;

            if (_voters.Any(x => x.Key == clientName && x.Value == roomName))
                return;

            if (_voters.Any(x => x.Key == clientName))
                _voters[clientName] = roomName;
            else
                _voters.Add(Context.User.Identity.Name, roomName);

            _rooms[roomVote.Key] += 1;

            List<Vote> votes = new List<Vote>();

            votes.Add(new Vote { RoomName = _rooms.ElementAt(0).Key.RoomName, Votes = _rooms.ElementAt(0).Value });
            votes.Add(new Vote { RoomName = _rooms.ElementAt(1).Key.RoomName, Votes = _rooms.ElementAt(1).Value });

            Clients.All.VoteCount(votes);
        }

        public void GetVotedForRoom()
        {
            Clients.Caller.SetRoom(_rooms.OrderByDescending(x => x.Value).First().Key);
        }
    }
}