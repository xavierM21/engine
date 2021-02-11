using System;
using System.Collections.Generic;
using System.Text;
using engine.Models;

namespace engine.ViewModels
{
    class GameSession
    {
        player CurrentPlayer { get; set; }
        
        public GameSession()
        {
            CurrentPlayer = new player(); // creates a new player object and put that on line 10(playre CurrentPlayer { get; set; }
            CurrentPlayer.Name = "xav";
            CurrentPlayer.Gold = 1000000;

        }
    }
}
