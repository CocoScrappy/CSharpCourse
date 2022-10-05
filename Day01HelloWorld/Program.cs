using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day01HelloWorld
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.Write("What is your name?");
            string name = Console.ReadLine();
            Console.Write("What is your age?");
            string ageStr = Console.ReadLine();
            if (int.TryParse(ageStr, out int age))
            {
                Console.WriteLine($"hello {name}! you are " +
                    $"{ageStr} years old.");
                Console.WriteLine("Hello {0}, you are {1} y/o. " +
                    "Nice to meet you {0}!");
            }
            if (name.ToLower() == "mark") { Console.WriteLine("Oh hi Mark!"); }
            else { Console.WriteLine("invalid numerical input"); }
            Console.ReadKey();


            //    string ageStr = Console.ReadLine();
            //try
            //{
            //    int age = int.Parse(ageStr);
            //    Console.WriteLine($"hello {name}! you are {ageStr} years old.");
            //}
            //catch (FormatException ex)
            //{
            //    Console.WriteLine("invalid numerical input");
            //}
            //finally
            //{
            //    Console.ReadKey();
            //}
        }
    }
}
