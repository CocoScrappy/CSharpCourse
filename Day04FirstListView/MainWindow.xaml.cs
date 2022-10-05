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

namespace Day04FirstListView
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


        private void btnAddPerson_Click(object sender, RoutedEventArgs e)
        {
            //TODO: add validation
            string name = tbxName.Text;
            int.TryParse(tbxAge.Text, out int age);//FIXME: if ....
            LvPeople.Items.Add($"{name} is {age} y/o");
            //clear inputs
            tbxName.Text = "";
            tbxAge.Text = "";
        }
    }
}
