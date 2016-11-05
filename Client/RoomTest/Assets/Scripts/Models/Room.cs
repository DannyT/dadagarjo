using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Models
{
    [Serializable]
    public class Room
    {
        public string RoomName { get; set; }
        
        public int EntryLocation { get; set; }

        public int ExitLocation { get; set; }

        public bool HasReward { get; set; }
    }
}
