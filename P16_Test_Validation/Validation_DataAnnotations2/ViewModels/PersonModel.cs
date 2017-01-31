using System.ComponentModel.DataAnnotations;

namespace Validation_DataAnnotations2.ViewModels
{
    /// <summary>
    /// Class for the viewmodel-properties to validate and their data annotations.
    /// </summary>
    public class PersonModel
    {
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        [Required(ErrorMessage = "The first name has to be inserted")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        [Required(ErrorMessage = "The last name has to be inserted")]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the age.
        /// </summary>
        [Range(1, 130, ErrorMessage = "The age must be a number between {1} and {2}")]
        public int Age { get; set; }

        /// <summary>
        /// Gets or sets the selected gender.
        /// </summary>
        [Required(ErrorMessage = "The gender has to be selected")]
        public string SelectedGender { get; set; }

    }
}
