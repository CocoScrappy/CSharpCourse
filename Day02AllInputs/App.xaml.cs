using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Day02AllInputs
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    ///         const string DataFileName = @"..\..\people.txt";

    //          static List<Person> People = new List<Person>();
    public partial class App : Application
    {
    }

    class InvalidNameException : Exception
    {
        public InvalidNameException() { }

        public InvalidNameException(string name)
            : base(String.Format("Invalid Name: {0}", name))
        {

        }
    }
}
