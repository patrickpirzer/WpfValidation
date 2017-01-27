using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Validation_IDataErrorInfo
{
    /// <summary>
    /// http://stackoverflow.com/questions/22361803/data-annotations-idataerrorinfo-and-mvvm
    /// https://blog.magnusmontin.net/2013/08/26/data-validation-in-wpf/
    /// </summary>
    public class PersonViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        /// <summary>
        /// Eventhandler for signalising that a property has changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        //[Required(ErrorMessage ="You must input the first name")]
        [Required(AllowEmptyStrings = false)]
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        public string FirstName { get; set; }

        //[Required(ErrorMessage = "You must input the last name")]
        [Required(AllowEmptyStrings = false)]
        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Informs the target which is bound to a property, that it's source was changed and that it shall update.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Error
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string this[string columnName]
        {
            get
            {
                ////return OnValidate(columnName);
                switch (columnName)
                {
                    case "FirstName":
                        if (string.IsNullOrWhiteSpace(FirstName))
                            return "Please insert the first name";
                        break;
                    case "LastName":
                        if (string.IsNullOrWhiteSpace(LastName))
                            return "Please insert the last name";
                        break;
                }

                return string.Empty;
            }
        }

        ////protected virtual string OnValidate(string propertyName)
        ////{
        ////    if (string.IsNullOrEmpty(propertyName))
        ////        throw new ArgumentException("Property may not be null or empty", propertyName);

        ////    string error = string.Empty;

        ////    var value = this.GetType().GetProperty(propertyName).GetValue(this, null);
        ////    var results = new List<ValidationResult>();

        ////    var context = new ValidationContext(this, null, null) { MemberName = propertyName };

        ////    var result = Validator.TryValidateProperty(value, context, results);

        ////    if (!result)
        ////    {
        ////        var validationResult = results.First();
        ////        error = validationResult.ErrorMessage;
        ////    }
        ////    return error;
        ////}

    }
}
