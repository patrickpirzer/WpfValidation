using System;
using System.ComponentModel;

namespace Validation_IDataErrorInfo
{
    /// <summary>
    /// https://blog.magnusmontin.net/2013/08/26/data-validation-in-wpf/
    /// Interessant:
    /// http://stackoverflow.com/questions/6530529/enable-disable-save-button-during-validation-using-idataerrorinfo
    /// </summary>
    public class PersonViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        /// <summary>
        /// Field for a string array containing the names of the properties to validate.
        /// </summary>
        private readonly string[] ValidateProperties =
        {
            "FirstName", "LastName", "Age"
        };

        /// <summary>
        /// Eventhandler for signalising that a property has changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the age.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Informs the target which is bound to a property, that it's source was changed and that it shall update.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// ???
        /// </summary>
        public string Error
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Validates the property with the given name.
        /// </summary>
        /// <param name="propertyName">The name of the property to validate.</param>
        /// <returns>
        /// If successful the method returns string.empty. Otherwise it returns an error message.
        /// </returns>
        public string this[string propertyName]
        {
            get
            {
                //return OnValidate(propertyName);

                // New version.
                // Each change in the input fields causes a refresh of the property CanSave.
                // And there is no need to code the properties for validation explicitly - inclusive RaisePropertyChanged of CanSave.
                string result = OnValidate(propertyName);
                RaisePropertyChanged("CanSave");
                return result;
            }
        }

        /// <summary>
        /// Gets if all data is valid.
        /// </summary>
        public bool IsValid
        {
            get
            {
                foreach (string property in ValidateProperties)
                {
                    if (!string.IsNullOrWhiteSpace(OnValidate(property)))
                    {
                        // There is an error
                        return false;
                    }
                }
                return true;
            }
        }

        /// <summary>
        /// Gets if the data can be saved.
        /// </summary>
        public bool CanSave
        {
            get
            {
                return IsValid;
            }
        }

        /// <summary>
        /// Validates the given data.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns>
        /// If successful the method returns string.empty. Otherwise it returns an error message.
        /// </returns>
        private string OnValidate(string propertyName)
        {
            switch (propertyName)
            {
                case "FirstName":
                    if (string.IsNullOrWhiteSpace(FirstName))
                        return "Please insert the first name";
                    break;
                case "LastName":
                    if (string.IsNullOrWhiteSpace(LastName))
                        return "Please insert the last name";
                    break;
                case "Age":
                    if (string.IsNullOrWhiteSpace(Age.ToString()))
                        return "Input a valid number";
                    break;
            }

            return string.Empty;
        }

    }
}
