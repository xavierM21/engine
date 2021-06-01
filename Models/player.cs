using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Linq;
using System.Collections.ObjectModel;

namespace engine.Models
{
    public class player : basenotification  // public is there to make this class and vars visiable to the entire program.
                                            //INotifyProertyChanged makes sure that the program listens to these variables so when they chagned they are updated to the main window
    {
        // get and set means that you can get the value and set the value of the string and int

        private string _Name;
        private string _CharClass;
        private int _HP;
        private int _XP;
        private int _Lvl;
        private int _Gold;

        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                onPropertyChanged(nameof(Name));
            }
        }
        public string CharClass
        {
            get { return _CharClass; }
            set
            {
                _CharClass = value;
                onPropertyChanged(nameof(CharClass));
            }
        }
        public int HP
        {
            get { return _HP; }
            set
            {
                _HP = value;
                onPropertyChanged(nameof(HP));
            }
        }
        public int XP
        {
            get { return _XP; }
            set
            {
                _XP = value;
                onPropertyChanged(nameof(XP));
            }
        }
        public int Lvl
        {
            get { return _Lvl; }
            set
            {
                _Lvl = value;
                onPropertyChanged(nameof(Lvl));
            }
        }
        public int Gold
        {
            get { return _Gold; }
            set
            {
                _Gold = value;
                onPropertyChanged(nameof(Gold));
            }
        }

        public ObservableCollection<GameItem> Inventory { get; set; }
        public ObservableCollection<QuestStatus> Quests { get; set; }

        public player()
        {
            Inventory = new ObservableCollection<GameItem>();
            Quests = new ObservableCollection<QuestStatus>();
        }

        // vvv required for Inotify vvv

        // removed for simplicity so code doesnt get repeated and clunky/ugly. moved to basenotification.cs

    }
}
