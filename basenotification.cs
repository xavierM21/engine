using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace engine
{
    public class basenotification
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void onPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
