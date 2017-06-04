using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Presenter
{
    public class Saturn : INotifyPropertyChanged
    {
        private Uri imageFileName;

        public Uri ImageFileName
        {
            get { return imageFileName; }
            set
            {
                imageFileName = value;
                SendPropertyChanged("ImageFileName");
            }
        }

        private double temperature;

        public double Temperature
        {
            get { return temperature; }
            set 
            { 
                temperature = value;
                SendPropertyChanged("Temperature");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void SendPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, 
                    new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
