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

namespace Day02WPFHelloWorld
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnSayHelloLabel_Click(object sender, RoutedEventArgs e)
        {
            string name = TbxName.Text;
            // validation
            if (name == "")
            {
                MessageBox.Show("Name must npt be empty.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            LblGreeting.Content = $"Hello {name}, nice to meet you!";
        }
        private void BtnSayHelloPopup_Click(object sender, RoutedEventArgs e)
        {
            string name = TbxName.Text;
            // validation
            if (name == "")
            {
                MessageBox.Show("Name must npt be empty.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MessageBox.Show($"Hello {name}, nice to meet you!", "Greeting", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
