using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace engine
{
    public class basenotification : INotifyPropertyChanged // added so this actually works | edited, fixed 5/31
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void onPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}


// basenotification.cs
// vvvvProperty changed & onProperyChanged() vvvv
// can be used in: player.cs | gamesession.cs