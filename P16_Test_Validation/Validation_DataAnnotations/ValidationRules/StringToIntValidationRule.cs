using System.Globalization;
using System.Windows.Controls;

namespace Validation_DataAnnotations.ValidationRules
{
    /// <summary>
    /// Class for validating int values.
    /// </summary>
    public class StringToIntValidationRule : ValidationRule
    {
        /// <summary>
        /// Validates if the given value is a number.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="cultureInfo">The culture info.</param>
        /// <returns>Returns an object of type ValidationResult.</returns>
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int i;
            if (int.TryParse(value.ToString(), out i))
                return new ValidationResult(true, null);

            return new ValidationResult(false, "Please insert a valid number.");
        }

    }
}
