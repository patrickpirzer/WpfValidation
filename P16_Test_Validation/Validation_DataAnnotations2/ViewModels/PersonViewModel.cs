using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Validation_DataAnnotations2.ViewModels
{
    /// <summary>
    /// Class for the administration of person data.
    /// </summary>
    public class PersonViewModel : INotifyDataErrorInfo
    {
        /// <summary>
        /// Field for the validation errors.
        /// </summary>
        private readonly Dictionary<string, ICollection<string>> validationErrors = new Dictionary<string, ICollection<string>>();

        /// <summary>
        /// Field for an instance of the <see cref="PersonModel"/> class.
        /// </summary>
        private readonly PersonModel personmodel = new PersonModel();

        /// <summary>
        /// The constructor.
        /// </summary>
        public PersonViewModel()
        {
            // Creates the list with the genders.
            GenderList = new List<string>();
            GenderList.Add("Male");
            GenderList.Add("Female");

            // Initializes the first validation.
            // When the window which uses this viewmodel has loaded, the errors are displayed and the save-button is disabled.
            ValidateModel();
        }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        public string FirstName
        {
            get { return personmodel.FirstName; }
            set
            {
                personmodel.FirstName = value;
                ValidateModelProperty(value, "FirstName");
            }
        }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        public string LastName
        {
            get { return personmodel.LastName; }
            set
            {
                personmodel.LastName = value;
                ValidateModelProperty(value, "LastName");
            }
        }

        /// <summary>
        /// Gets or sets the age.
        /// </summary>
        public int Age
        {
            get { return personmodel.Age; }
            set
            {
                personmodel.Age = value;
                ValidateModelProperty(value, "Age");
            }
        }

        /// <summary>
        /// Gets the list with the genders.
        /// </summary>
        public List<string> GenderList { get; }

        /// <summary>
        /// Gets or sets the selected gender.
        /// </summary>
        public string SelectedGender
        {
            get { return personmodel.SelectedGender; }
            set
            {
                personmodel.SelectedGender = value;
                ValidateModelProperty(value, "SelectedGender");
            }
        }

        /// <summary>
        /// Validates the given value to the model property.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="propertyName">The name of the property.</param>
        protected void ValidateModelProperty(object value, string propertyName)
        {
            if (validationErrors.ContainsKey(propertyName))
                validationErrors.Remove(propertyName);

            ICollection<ValidationResult> validationResults = new List<ValidationResult>();

            ValidationContext validationContext =
                new ValidationContext(personmodel, null, null) { MemberName = propertyName };

            if (!Validator.TryValidateProperty(value, validationContext, validationResults))
            {
                validationErrors.Add(propertyName, new List<string>());

                foreach (ValidationResult validationResult in validationResults)
                {
                    validationErrors[propertyName].Add(validationResult.ErrorMessage);
                }
            }

            RaiseErrorsChanged(propertyName);
        }

        /// <summary>
        /// 
        /// </summary>
        protected void ValidateModel()
        {
            validationErrors.Clear();
            ICollection<ValidationResult> validationResults = new List<ValidationResult>();
            ValidationContext validationContext = new ValidationContext(personmodel, null, null);
            if (!Validator.TryValidateObject(personmodel, validationContext, validationResults, true))
            {
                foreach (ValidationResult validationResult in validationResults)
                {
                    string property = validationResult.MemberNames.ElementAt(0);
                    if (validationErrors.ContainsKey(property))
                    {
                        validationErrors[property].Add(validationResult.ErrorMessage);
                    }
                    else
                    {
                        validationErrors.Add(property, new List<string> { validationResult.ErrorMessage });
                    }
                }
            }

            // Raises the ErrorsChanged for all properties explicitly.
            RaiseErrorsChanged("FirstName");
            RaiseErrorsChanged("LastName");
            RaiseErrorsChanged("Age");
            RaiseErrorsChanged("SelectedGender");
        }

        #region INotifyDataErrorInfo members

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        /// <summary>
        /// Actualizes the validation error list.
        /// </summary>
        /// <param name="propertyName"></param>
        private void RaiseErrorsChanged(string propertyName)
        {
            if (ErrorsChanged != null)
                ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Gets the errors to the given property.
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns>
        /// In case of success the method returns null. In case of error the method returns a list of type IEnumerable.
        /// </returns>
        public System.Collections.IEnumerable GetErrors(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName)
                || !validationErrors.ContainsKey(propertyName))
                return null;

            return validationErrors[propertyName];
        }

        /// <summary>
        /// Gets if the validation has found errors.
        /// </summary>
        public bool HasErrors
        {
            get { return validationErrors.Count > 0; }
        }

        #endregion

    }
}
