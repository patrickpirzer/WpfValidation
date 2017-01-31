using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Validation_IDataErrorInfo2
{
    /// <summary>
    /// https://blog.magnusmontin.net/2013/08/26/data-validation-in-wpf/
    /// Very interesting:
    /// http://stackoverflow.com/questions/6530529/enable-disable-save-button-during-validation-using-idataerrorinfo
    /// Disabling the Save-button without a special ViewModel-property:
    /// https://tarundotnet.wordpress.com/2011/03/03/wpf-tutorial-how-to-use-idataerrorinfo-in-wpf/
    /// </summary>
    public class PersonViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        /// <summary>
        /// The constructor.
        /// </summary>
        public PersonViewModel()
        {
            // Sets the borders for the age.
            MinAge = 1;
            MaxAge = 130;

            // Creates the list with the genders.
            GenderList = new List<string>();
            GenderList.Add("Male");
            GenderList.Add("Female");
        }

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
        /// Gets the minimal acceptable age.
        /// </summary>
        public int MinAge { get; private set; }

        /// <summary>
        /// Gets the maximal acceptable age.
        /// </summary>
        public int MaxAge { get; private set; }

        /// <summary>
        /// Gets the list with the genders.
        /// </summary>
        public List<string> GenderList { get; }

        /// <summary>
        /// Gets or sets the selected gender.
        /// </summary>
        public string SelectedGender { get; set; }

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
                return OnValidate(propertyName);
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
                    //if (Age < 1)
                    //    return "Age cannot be less than 1";
                    if (Age < MinAge || Age > MaxAge)
                        return "Age must be a number between " + MinAge + " and " + MaxAge;
                    break;
                case "SelectedGender":
                    if (string.IsNullOrWhiteSpace(SelectedGender))
                        return "Please select the gender";
                    break;
            }

            return string.Empty;
        }

    }
}
