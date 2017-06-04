using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace WpfLinq2Objects
{
    /// <summary>
    /// Converter zum Umwandeln von Long Geschwindigkeits Werten in 
    /// String.
    /// 100 --> 100 Mb/s
    /// 1000 --> 1.000 Mb/s
    /// </summary>
    public class SpeedConverter : IValueConverter
    {

        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // Konvertierung vom Objekt zum Wpf Element
            long speed = (long)value;

            if (speed > 1000 * 1000)
                return String.Format("{0:0.00}gb/s", speed / (1000 * 1000));
            else if (speed > 1000)
                return String.Format("{0:0}mb/s", speed / 1000);
            else
                return String.Format("{0:0}kb/s", speed);

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // Rückkonvertierung vom Wpf Element zum Objekt
            // Hier: Nicht implementiert.

            throw new NotImplementedException();
        }

        #endregion
    }
}
