using System.ComponentModel;

namespace Validation_ValidationRule
{
    /// <summary>
    /// https://blog.magnusmontin.net/2013/08/26/data-validation-in-wpf/
    /// https://msdn.microsoft.com/de-de/library/ms753962(v=vs.110).aspx
    /// </summary>
    public class PersonViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Eventhandler for signalising that a property has changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets the age.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Gets or sets the second age value.
        /// </summary>
        public int Age2 { get; set; }

        /// <summary>
        /// Gets or sets the name of the person.
        /// </summary>
        public string PersonName { get; set; }

        /// <summary>
        /// Informs the target which is bound to a property, that it's source was changed and that it shall update.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
