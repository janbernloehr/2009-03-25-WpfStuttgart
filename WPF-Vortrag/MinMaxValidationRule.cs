using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace Presenter
{
    class MinMaxValidationRule : ValidationRule
    {
        public double Minimum { get; set; }

        public double Maximum { get; set; }
        
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            double valueTyped;
            bool isDouble = Double.TryParse((string)value, out valueTyped);
            if (isDouble && (Minimum <= valueTyped) && 
                (valueTyped <= Maximum))
            {
                return new ValidationResult(true, null);
            }
            return new ValidationResult(false, "The value typed should be between " + Minimum + " and " + Maximum + ".");
        }
    }
}
