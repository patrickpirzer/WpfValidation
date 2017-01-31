using System.Globalization;
using System.Windows.Controls;

namespace Validation_IDataErrorInfo2.ValidationRules
{
    /// <summary>
    /// Class for the validation of age.
    /// </summary>
    public class AgeValidation : ValidationRule
    {
        /// <summary>
        /// Field for the minimal acceptable age.
        /// </summary>
        private int minAge;

        /// <summary>
        /// Gets or sets the minimal acceptable age.
        /// </summary>
        public int MinAge
        {
            get { return minAge; }
            set { minAge = value; }
        }

        /// <summary>
        /// Makes the validation.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="cultureInfo">The culture info.</param>
        /// <returns>Returns an object of type ValidationResult.</returns>
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int age;
            bool noIllegalChars = int.TryParse(value.ToString(), out age);

            if (string.IsNullOrWhiteSpace(value.ToString())) //(value.ToString().Length < 1)
            {
                // Value cannot be empty.
                return new ValidationResult(false, "Age field cannot be empty");
            }
            else if (noIllegalChars == false)
            {
                return new ValidationResult(false, "Age doesn't accept illegal characters");
            }
            else if (age < MinAge)
            {
                return new ValidationResult(false, "Age cannot be less than " + MinAge.ToString());
            }

            return new ValidationResult(true, null);
        }

    }
}
