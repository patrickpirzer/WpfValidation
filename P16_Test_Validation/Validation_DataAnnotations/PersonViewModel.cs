using System.ComponentModel.DataAnnotations;

namespace Validation_DataAnnotations
{
    /// <summary>
    /// Example for implementation in MVVM:
    /// https://social.technet.microsoft.com/wiki/contents/articles/22660.data-validation-in-mvvm.aspx
    /// https://code.msdn.microsoft.com/windowsdesktop/Validation-in-MVVM-using-12dafef3
    /// Existing Data-Annotations:
    /// https://msdn.microsoft.com/en-us/library/cc490428.aspx
    /// http://www.c-sharpcorner.com/UploadFile/af66b7/data-annotations-for-mvc/
    /// </summary>
    public class PersonViewModel : PropertyChangedNotification
    {
        [Required(ErrorMessage = "You must input the first name")]
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        public string FirstName
        {
            get { return GetValue(() => FirstName); }
            set { SetValue(() => FirstName, value); }
        }

        [Required(ErrorMessage = "You must input the last name")]
        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        public string LastName
        {
            get { return GetValue(() => LastName); }
            set { SetValue(() => LastName, value); }
        }

        //[RegularExpression(@"^[0-9]{1,3}$", ErrorMessage = "Please enter a valid number")]
        [Range(1, 100, ErrorMessage = "Age should be between 1 to 100")]
        /// <summary>
        /// Gets or sets the age.
        /// </summary>
        public int Age
        {
            get { return GetValue(() => Age); }
            set { SetValue(() => Age, value); }
        }

    }
}
