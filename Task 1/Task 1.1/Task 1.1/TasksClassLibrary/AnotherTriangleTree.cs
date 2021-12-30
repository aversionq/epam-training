using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksClassLibrary
{
    public class AnotherTriangleTree
    {
        public static void AnotherTriangle()
        {
            string inputNum, shift, starString;
            int rows, starCount = 1;
            bool inputCheck;

            Console.Write("Введите N: ");
            inputNum = Console.ReadLine();
            inputCheck = Int32.TryParse(inputNum, out rows);

            if (inputCheck)
            {
                for (int i = 0; i < rows; ++i)
                {
                    shift = new String(' ', rows - i - 1);
                    starString = new String('*', starCount);
                    starCount += 2;
                    Console.WriteLine(shift + starString);
                }
            }
            else
            {
                Console.WriteLine("Введены некорректные данные.");
            }
        }
    }
}
