using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksClassLibrary
{
    public class SumOfMultiple
    {
        public static void SumOfNumbers()
        {
            int sumOfNum = 0;
            for (int i = 0; i < 1000; ++i)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    sumOfNum += i;
                }
            }
            Console.WriteLine("Сумма чисел меньше 1000, кратных 3 или 5 = " + sumOfNum);
        }
    }
}
