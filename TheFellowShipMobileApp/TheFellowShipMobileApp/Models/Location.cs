using System;
using System.Collections.Generic;
using System.Text;

namespace TheFellowShipMobileApp.Models
{
    public enum Types
    {
        Empty,
        Firewall,
        Netgull,
        Mcafee,
        Player
    }
    public class Location
    {
        public int x { get; set; }
        public int y { get; set; }

        public Types types { get; set; }
    }
}
