using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace WpfApplication7
{
    class CrazyListBoxConverter : IValueConverter
    {
        public StudentProgram StudentProgram {
            get;
            set;
        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            Person p = value as Person;
            double scale = 200;

            if (p == null) return null;

            double index = StudentProgram.StudentPartners.IndexOf(p);
            double count = StudentProgram.StudentPartners.Count;

            double angle = index / count * 360;
            double left = scale * (1 + Math.Sin(index / count * 2 * Math.PI));
            double top = scale * (1 - Math.Cos(index / count * 2 * Math.PI));

            switch ((string)parameter) {
                case "Top":
                    return top;
                case "Left":
                    return left;
                case "Angle":
                    return angle;
            }

            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
