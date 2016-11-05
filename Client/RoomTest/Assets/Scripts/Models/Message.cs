using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Models
{
    [Serializable] 
    public class Message
    {
        public string H { get; set; }
        public string M { get; set; }
        public string[] A { get; set; }
    }
}
