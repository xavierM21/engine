using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Linq;
using engine.Models;
using engine.Factories;


namespace engine.ViewModels

{
    public class GameSession : basenotification
    {
        private Location _currentLocation;
        public World CurrentWorld { get; set; } 
        public player CurrentPlayer { get; set; }
        public Location CurrentLocation
        {
            get { return _currentLocation; }
            set
            {
                _currentLocation = value;

                onPropertyChanged(nameof(CurrentLocation));
                onPropertyChanged(nameof(HaslocationToNorth));
                onPropertyChanged(nameof(HaslocationToEast));
                onPropertyChanged(nameof(HaslocationToSouth));
                onPropertyChanged(nameof(HaslocationToWest));

                GivePlayerQuestsAtLocation();
            }
        }

        public bool HaslocationToNorth
        {
            get
            {
                return CurrentWorld.LocationAt(CurrentLocation.XCoord, CurrentLocation.YCoord + 1) != null;

            }
        }
        public bool HaslocationToEast
        {
            get
            {
                return CurrentWorld.LocationAt(CurrentLocation.XCoord + 1, CurrentLocation.YCoord) != null;

            }
        }
        public bool HaslocationToSouth
        {
            get
            {
                return CurrentWorld.LocationAt(CurrentLocation.XCoord, CurrentLocation.YCoord - 1) != null;

            }
        }
        public bool HaslocationToWest
        {
            get
            {
                return CurrentWorld.LocationAt(CurrentLocation.XCoord - 1, CurrentLocation.YCoord) != null;

            }
        }

        public GameSession()
        {
            CurrentPlayer = new player 
                {
                    Name = "xav", 
                    CharClass = "night", 
                    Gold = 10000, 
                    HP = 10, 
                    Lvl = 1, 
                    XP = 0
                }; 
            // creates a new player object and put that on line 10(playre CurrentPlayer { get; set; }
            // removed unnessacary code, looks cleaner right? :D
    

            CurrentWorld = WorldFactory.CreateWorld();

            CurrentLocation = CurrentWorld.LocationAt(0, -1);
            CurrentPlayer.Inventory.Add(ItemFactory.CreateGameItem(1001));
            CurrentPlayer.Inventory.Add(ItemFactory.CreateGameItem(1002));
            CurrentPlayer.Inventory.Add(ItemFactory.CreateGameItem(1002));
        }

        public void MoveNorth()
        {
            if(HaslocationToNorth)
            {
                CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoord, CurrentLocation.YCoord + 1);
            }
        }

        public void MoveWest()
        {
            if(HaslocationToWest)
            {
                CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoord - 1, CurrentLocation.YCoord);
            }
        }

        public void MoveEast()
        {
            if (HaslocationToEast)
            {
                CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoord + 1, CurrentLocation.YCoord);
            }
        }

        public void MoveSouth()  
        {
            if(HaslocationToSouth)
            {
                CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoord, CurrentLocation.YCoord - 1);
            }
        }
        //removed, explanation at player.cs | check basenotification
        private void GivePlayerQuestsAtLocation()
        {
            foreach(Quest quest in CurrentLocation.QuestsAvailableHere)
            {
                if(!CurrentPlayer.Quests.Any(q => q.PlayerQuest.ID == quest.ID))
                {
                    CurrentPlayer.Quests.Add(new QuestStatus(quest));
                }
            }
        }
    }
}
