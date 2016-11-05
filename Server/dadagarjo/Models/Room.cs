using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dadagarjo.Models
{
    public class Room
    {
        public string RoomName { get; set; }

        public int EntryLocation { get; set; }

        public int ExitLocation { get; set; }

        public bool HasReward { get; set; }
    }
}