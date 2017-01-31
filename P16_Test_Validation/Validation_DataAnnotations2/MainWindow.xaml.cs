using System.Windows;
using Validation_DataAnnotations2.ViewModels;

namespace Validation_DataAnnotations2
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Field for an instance of the <see cref="PersonViewModel"/> class.
        /// </summary>
        PersonViewModel pvm = new PersonViewModel();

        /// <summary>
        /// The constructor of the window.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            DataContext = pvm;
        }

        /// <summary>
        /// Button-click for debug-testing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_test_Click(object sender, RoutedEventArgs e)
        {
            //
        }

    }
}
