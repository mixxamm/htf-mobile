using System;
using System.Collections.Generic;
using System.Text;

namespace TheFellowShipMobileApp.Models
{
    public class Location
    {
        public int x { get; set; }
        public int y { get; set; }

        public enum type
        {
            Empty,
            Firewall,
            Netgull,
            Mcafee,
            Player
        }
    }
}
