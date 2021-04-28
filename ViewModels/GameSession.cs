using System;
using System.Collections.Generic;
using System.Text;
using engine.Models;
using engine.Factories;
namespace engine.ViewModels
{
    public class GameSession
    {
        public World CurrentWorld { get; set; }
        public player CurrentPlayer { get; set; }
        public Location CurrentLocation { get; set; }
        
        public GameSession()
        {
            CurrentPlayer = new player(); // creates a new player object and put that on line 10(playre CurrentPlayer { get; set; }
            CurrentPlayer.Name = "xav";
            CurrentPlayer.Gold = 1000000;
            CurrentPlayer.HP = 10;
            CurrentPlayer.CharClass = "fighter";
            CurrentPlayer.Lvl = 1;
            CurrentPlayer.XP = 0;

            WorldFactory factory = new WorldFactory();
            CurrentWorld = factory.CreateWorld();

            CurrentLocation = CurrentWorld.LocationAt(0, -1);

        }
    }
}
