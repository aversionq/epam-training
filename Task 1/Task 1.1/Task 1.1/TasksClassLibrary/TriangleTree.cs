using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksClassLibrary
{
    public class TriangleTree
    {
        public static void Triangle()
        {
            string inputNum, starString = "*";
            int rows;
            bool inputCheck;

            Console.Write("Введите N: ");
            inputNum = Console.ReadLine();
            inputCheck = Int32.TryParse(inputNum, out rows);

            if (inputCheck)
            {
                for (int i = 0; i < rows; ++i)
                {
                    Console.WriteLine(starString);
                    starString += "*";
                }
            }
            else
            {
                Console.WriteLine("Введены некорректные данные.");
            }
        }
    }
}
