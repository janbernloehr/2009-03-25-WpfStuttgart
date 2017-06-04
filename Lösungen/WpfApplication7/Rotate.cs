using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Media;
using System.Windows.Data;

namespace WpfApplication7
{
    public class NumberConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            double number = (double)value;
            double factor;

            if (parameter is string) {
                factor = double.Parse((string)parameter);
            } else {
                factor = (double)parameter;
            }

            return number * factor;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            throw new NotImplementedException();
        }
    }

    public class Rotation
    {
        public static DependencyProperty IsEnabledProperty = DependencyProperty.RegisterAttached(
            "IsEnabled",
            typeof(bool),
            typeof(Rotation),
            new PropertyMetadata(false, new PropertyChangedCallback(IsEnabledPropertyChanged)));

        public static void IsEnabledPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            bool newValue = (bool)e.NewValue;
            bool oldValue = (bool)e.OldValue;

            if (oldValue == false & newValue == true) {
                // get the stroyboard from resources
                Storyboard sb = (Storyboard)App.Current.Resources["RotateStoryboard"];

                // make sure we have a framework element!
                FrameworkElement fe = (FrameworkElement)d;

                // make sure we have a RotateTransform
                RotateTransform rt = fe.RenderTransform as RotateTransform;

                if (rt == null) {
                    rt = new RotateTransform();

                    Binding bindingX = new Binding("ActualWidth");
                    bindingX.Source = fe;
                    bindingX.Converter = new NumberConverter();
                    bindingX.ConverterParameter = 0.5D;

                    Binding bindingY = new Binding("ActualHeight");
                    bindingY.Source = fe;
                    bindingY.Converter = new NumberConverter();
                    bindingY.ConverterParameter = 0.5D;

                    BindingOperations.SetBinding(rt, RotateTransform.CenterXProperty, bindingX);
                    BindingOperations.SetBinding(rt, RotateTransform.CenterYProperty, bindingY);

                    fe.RenderTransform = rt;
                }

                // begin the storyboard.
                sb.Begin(fe);
            } else if (oldValue == true & newValue == false) {
                // TODO: Stop when the value is set to false.
            }
        }

        public static bool GetIsEnabled(UIElement element) {
            return (bool)element.GetValue(IsEnabledProperty);
        }

        public static void SetIsEnabled(UIElement element, bool value) {
            element.SetValue(IsEnabledProperty, value);
        }
    }


}
