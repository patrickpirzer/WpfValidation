using System;
using System.Globalization;
using System.Windows.Controls;

namespace Validation_ValidationRule.ValidationRules
{
    /// <summary>
    /// Class for validation of given age.
    /// This has to be a value between the borders which are defined in the XAML.
    /// </summary>
    public class AgeRangeRule : ValidationRule
    {
        private int _min;
        private int _max;

        public AgeRangeRule()
        {
        }

        public int Min
        {
            get { return _min; }
            set { _min = value; }
        }

        public int Max
        {
            get { return _max; }
            set { _max = value; }
        }

        /// <summary>
        /// Validates if the given value is between the defined borders.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="cultureInfo">The culture info.</param>
        /// <returns>Returns an object of type ValidationResult.</returns>
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int age = 0;

            try
            {
                if (((string)value).Length > 0)
                    age = Int32.Parse((String)value);
            }
            catch (Exception e)
            {
                return new ValidationResult(false, "Illegal characters or " + e.Message);
            }

            if ((age < Min) || (age > Max))
            {
                return new ValidationResult(false,
                  "Please insert a number between " + Min + " and " + Max + ".");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }

    }
}
