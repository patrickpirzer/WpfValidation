using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Validation_IDataErrorInfo2
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Field for the viewmodel.
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
