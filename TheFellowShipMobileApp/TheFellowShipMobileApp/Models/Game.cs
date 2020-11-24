using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TheFellowShipMobileApp.Models
{
    public enum GameStates
    {
        InProgress, Won, Dead
    }
    public enum Difficulties
    {
        Easy, Normal, Hard
    }
    public class Game
    {
        public string Id { get; set; }
        public int BoardWidth { get; set; }
        public int BoardHeight { get; set; }
        public IEnumerable<Location> NetgullLocations { get; set; }
        public IEnumerable<Location> FirewallLocations { get; set; }
        public Location PlayerLocation { get; set; }
        public Location McafeeLocation { get; set; }

        public GameStates GameState { get; set; }
        public Difficulties Difficulty { get; set; }
    }
}
