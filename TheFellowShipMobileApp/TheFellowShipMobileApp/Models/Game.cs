using System;
using System.Collections.Generic;
using System.Text;

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
        public int Id { get; set; }
        public int BoardWidth { get; set; }
        public int BoardHeight { get; set; }
        public List<Location> NetgullLocations { get; set; }
        public List<Location> FirewallLocations { get; set; }
        public List<Location> PlayerLocation { get; set; }
        public List<Location> McafeeLocation { get; set; }

        public GameStates GameState { get; set; }
        public Difficulties Difficulty { get; set; }
    }
}
