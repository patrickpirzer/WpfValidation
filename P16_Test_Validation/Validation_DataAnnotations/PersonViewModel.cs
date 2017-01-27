using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Validation_DataAnnotations
{
    /// <summary>
    /// https://social.technet.microsoft.com/wiki/contents/articles/22660.data-validation-in-mvvm.aspx
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

    }
}
