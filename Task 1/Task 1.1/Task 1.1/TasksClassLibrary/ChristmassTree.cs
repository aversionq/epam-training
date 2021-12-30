using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksClassLibrary
{
    public class ChristmassTree
    {
        public static void XMasTree()
        {
            string inputNum, shift, starString;
            int rows, starCount;
            bool inputCheck;

            Console.Write("Введите N: ");
            inputNum = Console.ReadLine();
            inputCheck = Int32.TryParse(inputNum, out rows);

            if (inputCheck)
            {
                for (int i = 1; i <= rows; ++i)
                {
                    starCount = 1;
                    for (int j = 0; j < i; ++j)
                    {
                        shift = new String(' ', rows - j - 1);
                        starString = new String('*', starCount);
                        starCount += 2;
                        Console.WriteLine(shift + starString);
                    }
                }
            }
            else
            {
                Console.WriteLine("Введены некорректные данные.");
            }
        }
    }
}
