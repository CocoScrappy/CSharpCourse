using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Day02AllInputs
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

        const string DataFileName = @"..\..\registrations.txt";

        private void RegisterOnClick(object sender, RoutedEventArgs e)
        {

            try
            {
                File.AppendAllText(DataFileName, getNewRecordValues());
                //MessageBox.Show("Data added to file", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            // catch errors of writing to file
            catch (Exception ex) when (ex is IOException || ex is SystemException)
            {
                ShowError(ex.Message);
            }
            catch (InvalidNameException)
            {
                ShowError("Name must be a proper name and cannot be left blank");
            }

            //catch (NullReferenceException)
            //{
            //    ShowError("Must select continent");
            //}
        }


        private string getNewRecordValues()
        {
            string name = personName.Text;
            string age = "";
            string pets = "";
            string temp = currentTempTextBlock.Text.Substring(currentTempTextBlock.Text.IndexOf(":") + 2);
            string continent;
            string newRecord;
            try
            {
                ValidateName(name);// ex InvalidNameException

                if (Btn1.IsChecked == true) { age = Btn1.Content.ToString(); }
                else if (Btn2.IsChecked == true) { age = Btn2.Content.ToString(); }
                else if (Btn3.IsChecked == true) { age = Btn3.Content.ToString(); }
                else { //internal error
                    MessageBox.Show(this, "Error reading radio buttons state", "Internal error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                if (chkCat.IsChecked == true) { pets += chkCat.Content.ToString() + ","; }
                else { pets += ","; }
                if (chkDog.IsChecked == true) { pets += chkDog.Content.ToString() + ","; }
                else { pets += ","; }
                if (chkOther.IsChecked == true) { pets += chkOther.Content.ToString() + ","; }

                continent = cboPickOne?.SelectedValue?.ToString();

                newRecord = $"{name};{age};{pets};{continent};{temp};\n"; // allow NullReference
            }
            catch (InvalidNameException)
            {
                throw;
            }

            //catch (NullReferenceException)
            //{
            //    throw;
            //}

            return newRecord;
        }


        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double val = Convert.ToDouble(e.NewValue);
            string msg = String.Format("Preferred temp C: {0:#,#.0}", val);
            this.currentTempTextBlock.Text = msg;
        }

        private static void ValidateName(String Name)
        {
            Regex regex = new Regex("^[a-zA-Z]+$");

            if (!regex.IsMatch(Name))
                throw new InvalidNameException(Name);
        }


        private void ShowError(string msg)
        {
            {
                MessageBox.Show(msg, "Input error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
