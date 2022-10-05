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

namespace TempConvMultiple
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

        private void ConvertOnChange(object sender, RoutedEventArgs e)
        {
            if (!this.IsLoaded) return;

            //RadioButton li = (sender as RadioButton);

            //find the radio element selected for In scale
            var radioButtonsIn = LogicalTreeHelper.GetChildren(InputScale).OfType<RadioButton>();
            var selectedIn = radioButtonsIn.FirstOrDefault(x => (bool)x.IsChecked);
            
            //base case - Celsius is selected
            double inputTempC = Double.Parse(Input.Text);
            //calculate left side value in Celsius if either other scale is selected
            if (selectedIn.Content.ToString() == "Fahrenheit")
            {
                inputTempC = (inputTempC - 32) * .5556;
            } else if (selectedIn.Content.ToString() == "Kelvin")
            {
                inputTempC = inputTempC - 273.15;
            }

            //find the radio elemenet selected for Out scale
            var radioButtonsOut = LogicalTreeHelper.GetChildren(OutputScale).OfType<RadioButton>();
            var selectedOut = radioButtonsOut.FirstOrDefault(x => (bool)x.IsChecked);

            //base case Output scale is in Celsius so set the OutputTemp equal to that Celsius value
            double outputTemp = inputTempC;
            //recalculate the Out value to Fahrenheit or Kelvin
            if (selectedOut.Content.ToString() == "Fahrenheit")
            {
                outputTemp = inputTempC / .5556 + 32;
            } else if (selectedOut.Content.ToString() == "Kelvin")
            {
                outputTemp = inputTempC + 273.15;
            }

            Output.Text = outputTemp.ToString();

        }

        private void ShowError(string msg)
        {
            {
                MessageBox.Show(msg, "Input error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
