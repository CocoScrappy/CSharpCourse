using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day01TextFile
{
    class Program
    {
        static void Main(string[] args)
        {   
            Console.WriteLine("Write your name: ");
            string name = Console.ReadLine();
            try
            {
                using (StreamWriter sw = new StreamWriter("./data.txt"))
                {
                    for (int i = 0; i < 3; i++)
                    {
                        sw.WriteLine(name);
                    }
                    //closing the file - automatic when leaving this block
                }
            }
            catch (e) { }
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Uh oh, someone entered an empty name!");
                Console.ReadKey();
            }
            else { 
                string readText = File.ReadAllText("./data.txt");
                Console.WriteLine(readText);
                Console.ReadKey();
            }

        }
    }
}