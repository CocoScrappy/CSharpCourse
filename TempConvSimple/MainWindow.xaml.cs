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

namespace TempConvSimple
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

        public void ConvertOnClick(object sender, RoutedEventArgs e)
        {
            if (!IsNumeric(Input.Text)) { ShowError("Temperature must be a number"); }
            else
            {
                double tempF = Convert.ToDouble(Input.Text);
                if (tempF<-459.67) { ShowError("Temperature is lower than absolute minimum"); }
                else { 
                    double tempC = (tempF - 32) * .5556;
                    Output.Text = tempC.ToString();

                    string msg = String.Format("{0:#,#.0}F is {1:#,#.0}C", tempF, tempC);
                    Desc.Content = msg;
                }
            }
        }

        public bool IsNumeric(String s)
        {
            return s.All(Char.IsDigit);
        }

        private void ShowError(string msg)
        {
            {
                MessageBox.Show(msg, "Input error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
