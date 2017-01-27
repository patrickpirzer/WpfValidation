using System.Globalization;
using System.Windows.Controls;

namespace Validation_ValidationRule.ValidationRules
{
    /// <summary>
    /// Class for validating that a string shall not be null or consists of whitespaces.
    /// </summary>
    public class StringNotEmptyRule : ValidationRule
    {
        /// <summary>
        /// Validates if the given value is not null or consists of whitespaces.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="cultureInfo">The culture info.</param>
        /// <returns>Returns an object of type ValidationResult.</returns>
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                return new ValidationResult(false, "Please insert a string");

            return new ValidationResult(true, null);
        }

    }
}
