using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Linq;
using engine.Models;
using engine.Factories;
using engine.EventArgs;


namespace engine.ViewModels

{
    public class GameSession : basenotification
    {
        public event EventHandler<GameMessageEventArgs> OnMessageRaised;
        private Location _currentLocation;
        private Monsters _currentMonster;
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
                GetMonsterAtLocation();
            }
        }

        public Monsters CurrentMonster
        {
            get { return _currentMonster; } 
            set
            {
                _currentMonster = value;
                onPropertyChanged(nameof(CurrentMonster));
                onPropertyChanged(nameof(HasMonster));
                if(CurrentMonster != null)
                {
                    RaiseMesssage("");
                    RaiseMesssage($"you see a {CurrentMonster.Name}here !");
                }
            }
        }
        public Weapon CurrentWeapon { get; set; }

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
        public bool HasMonster => CurrentMonster != null;

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
            if (!CurrentPlayer.Weapons.Any())
            {
                CurrentPlayer.AddItemToInventory(ItemFactory.CreateGameItem(1001));
            }

            CurrentWorld = WorldFactory.CreateWorld();

            CurrentLocation = CurrentWorld.LocationAt(0, -1);
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

        private void GetMonsterAtLocation()
        {
            CurrentMonster = CurrentLocation.GetMonster();
        }

        private void RaiseMesssage(string message)
        {
            OnMessageRaised?.Invoke(this, new GameMessageEventArgs(message));
        }
        public void AttackCurrentMonster()
        {
            if(CurrentWeapon == null)
            {
                RaiseMesssage("you must select a weapon");
                return;
            }
            int dmgToMonster = RNG.SimpleNumberBetween(CurrentWeapon.MinDmg, CurrentWeapon.MaxDmg);
            if (dmgToMonster == 0)
            {
                RaiseMesssage($"you hit the {CurrentMonster.Name} for {dmgToMonster} !");
            }
            else
            {
                CurrentMonster.HP -= dmgToMonster;
                RaiseMesssage($"you hit the {CurrentMonster.Name} for {dmgToMonster} !");
            }

            if(CurrentMonster.HP <= 0)
            {
                RaiseMesssage("");
                RaiseMesssage($"you defeated {CurrentMonster.Name}!");

                CurrentPlayer.XP += CurrentMonster.RewardXP;
                RaiseMesssage($"you gained {CurrentMonster.RewardXP} XP!");

                CurrentPlayer.Gold += CurrentMonster.RewardGold;
                RaiseMesssage($"you gained {CurrentMonster.RewardGold} gold!");

                foreach(ItemQuantity itemQuantity in CurrentMonster.Inventory)
                {
                    GameItem item = ItemFactory.CreateGameItem(itemQuantity.ItemID);
                    CurrentPlayer.AddItemToInventory(item);
                    RaiseMesssage($"you gained {itemQuantity.Quantity} {item.Name}");
                }
                GetMonsterAtLocation();
            }
            else
            {
                int dmgToPlayer = RNG.SimpleNumberBetween(CurrentMonster.MinDmg, CurrentMonster.MaxDmg);

                if(dmgToPlayer == 0 )
                {
                    RaiseMesssage("The monster attacts, you take no damage.");
                }
                else
                {
                    CurrentPlayer.HP -= dmgToPlayer;
                    RaiseMesssage($"the {CurrentMonster.Name} hit you for {dmgToPlayer}!");
                }
                if (CurrentPlayer.HP  <= 0)
                {
                    RaiseMesssage("");
                    RaiseMesssage($"the {CurrentMonster.Name} killed you");

                    CurrentLocation = CurrentWorld.LocationAt(0, -1);
                    CurrentPlayer.HP = CurrentPlayer.Lvl * 10;
                }
            }
        }

    }
}
