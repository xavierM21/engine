using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;
using engine.Models;
using engine.Factories;


namespace engine.ViewModels

{
    public class GameSession : INotifyPropertyChanged
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

                onPropertyChanged("CurrentLocation");
                onPropertyChanged("HasLocationToNorth");
                onPropertyChanged("HasLocationToEast");
                onPropertyChanged("HasLocationToWest");
                onPropertyChanged("HasLocationToSouth");
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

        public void MoveNorth()
        {
            CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoord, CurrentLocation.YCoord + 1);
        }

        public void MoveWest()
        {
            CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoord + 1, CurrentLocation.YCoord);
        }

        public void MoveEast()
        {
            CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoord, CurrentLocation.YCoord - 1);
        }

        public void MoveSouth()
        {
            CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoord - 1, CurrentLocation.YCoord);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void onPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
