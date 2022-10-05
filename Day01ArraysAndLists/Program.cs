using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day01ArraysAndLists
{
    class Program
    {
        static void Main(string[] args)
        {
            try { 
            // possibly a jagged array, only the first dimension is allocated
            int[][] twoDimInt = new int[4][];
            // rectangular array
            int[,] twoDimIntRectangular = new int[4, 3];
            int[,,] threeDimIntRect = new int[4, 3, 2]; // 3D: 4 x 3 x 2 size

            int[,] data2dInts = { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 18 } };
            //TASK: compute the average value (as floating point) of all values
            //in data 2dInts
            int sum=0;
            double avg;
            int count = 0;
            for (int i = 0; i < data2dInts.GetLength(0); i++)
            {
                for (int j = 0; j < data2dInts.GetLength(1); j++)
                {
                    sum += data2dInts[i,j];
                    count++;
                }
            }
            avg = (double)sum / (double)count;
            Console.WriteLine($"Average value is {avg:0.##}");
            Console.ReadKey();
            }
            finally
            {
                Console.WriteLine("press any key");
                Console.ReadKey();
            }
        }
    }
}
