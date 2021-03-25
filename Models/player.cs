using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace engine.Models
{
    public class player : INotifyPropertyChanged  // public is there to make this class and vars visiable to the entire program.
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
                OnPropertyChanged("Name");
            }
        }
        public string CharClass 
        {
            get { return _CharClass; }
            set
            {
                _CharClass = value;
                OnPropertyChanged("CharClass");
            } 
        }
        public int HP 
        {
            get { return _HP; }
            set
            {
                _HP = value;
                OnPropertyChanged("HP");
            }
        }
        public int XP 
        {
            get { return _XP; }
            set 
            {
                _XP = value;
                OnPropertyChanged("XP");
            }
        }
        public int Lvl 
        {
            get { return _Lvl; }
            set
            {
                _Lvl = value;
                OnPropertyChanged("Lvl");
            }
        }
        public int Gold 
        {
            get { return _Gold; }
            set
            {
                _Gold = value;
                OnPropertyChanged("Gold");
            }
        }

        // vvv required for Inotify vvv
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
