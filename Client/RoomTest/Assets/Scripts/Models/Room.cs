using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Models
{
    [Serializable]
    public class Room
    {
        public string RoomName;
        public int EntryLocation;
        public int ExitLocation;
        public bool HasReward;
    }
}
