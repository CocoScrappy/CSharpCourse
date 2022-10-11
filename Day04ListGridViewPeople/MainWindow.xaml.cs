﻿using System;
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

namespace Day04ListGridViewPeople
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<Person> peopleList = new List<Person>();

        public MainWindow()
        {
            InitializeComponent();
            LvPeople.ItemsSource = peopleList;
        }

        private void BtnAddPerson_Click(object sender, RoutedEventArgs e)
        {
            //validation
            if (!ArePersonInputsValid()) return;

            string name = TbxName.Text;
            int.TryParse(TbxAge.Text, out int age);
            peopleList.Add(new Person(name, age));
            LvPeople.Items.Refresh();// tell Listview data has changed

            ResetFields();
        }

        private void BtnDeletePerson_Click(object sender, RoutedEventArgs e)
        {
            Person currSelPer = LvPeople.SelectedItem as Person;
            if (currSelPer == null) return;
            if (MessageBox.Show("Are you sure you want to delete record?", "Please confirm", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                peopleList.Remove(currSelPer);
                LvPeople.Items.Refresh();// tell Listview data has changed

                ResetFields();
            }

        }

        private void BtnUpdatePerson_Click(object sender, RoutedEventArgs e)
        {
            Person currSelPer = LvPeople.SelectedItem as Person;
            if (currSelPer == null) return;
            if (!ArePersonInputsValid()) return;
            string name = TbxName.Text;
            int.TryParse(TbxAge.Text, out int age); // okay: no need to validate again
            currSelPer.Name = name;
            currSelPer.Age = age;
            LvPeople.Items.Refresh(); // tell ListView data has changed
            ResetFields();
        }

        private bool ArePersonInputsValid()
        {
            string name = TbxName.Text;
            if (!Person.IsNameValid(name, out string errorName))
            {
                MessageBox.Show(this, errorName, "Input error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            string strAge = TbxAge.Text;
            if (!Person.IsAgeValid(strAge, out string errorAge))
            {
                MessageBox.Show(this, errorAge, "Input error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        private void ResetFields()
        {
            TbxName.Text = "";
            TbxAge.Text = "";
        }

        private void LvPeople_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Person currSelPer = LvPeople.SelectedItem as Person;
            if (currSelPer == null)
            {
                ResetFields();
            }
            else
            {
                TbxName.Text = currSelPer.Name;
                TbxAge.Text = currSelPer.Age.ToString();
            }
        }

        private void MiExport_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LvPeople_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // user clicked on a non-item - deselect all
            LvPeople.UnselectAll();
        }

        private void DeleteCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            Person currSelPer = LvPeople.SelectedItem as Person;
            if (currSelPer.Name!=null)
            {
                e.CanExecute = true;
            } else
            {
                e.CanExecute = true;
            }


        }
    }
}
