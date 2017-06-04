using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace WpfApplication7
{
    /// <summary>
    /// Dieser Converter gibt bei einem übergebenem int-Wert größer als 100.000 true zurück,
    /// andernfalls false.
    /// </summary>
    public class CrazyHackerConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            int loc;

            loc = (int)value;

            if (loc > 100000) 
                return true;
            else
                return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
