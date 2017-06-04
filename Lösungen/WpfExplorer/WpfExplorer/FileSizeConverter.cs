using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace WpfExplorer
{
    /// <summary>
    /// Wandelt die Dateigröße von Byte in eine passende Größe Gigabyte, Megabyte, ... um.
    /// </summary>
    public class FileSizeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            long fileSize = System.Convert.ToInt64(value);

            if (fileSize > 1024 * 1024 * 1024)
                return String.Format("{0:0.00}GB", fileSize / (1024 * 1024 * 1024));
            else if (fileSize > 1024 * 1024 )
                return String.Format("{0:0.00}MB", fileSize / (1024 * 1024));
            else if (fileSize >  1024)
                return String.Format("{0:0}KB", fileSize / 1024);
            else
                return String.Format("{0:0}B", fileSize);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
