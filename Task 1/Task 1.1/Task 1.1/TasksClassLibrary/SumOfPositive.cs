using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksClassLibrary
{
    public class SumOfPositive
    {
        public static int NonNegativeSum()
        {
            int[] array = new int[10];
            int sum = 0;
            Random random = new Random();

            // Заолняем массив, одновременно выводим его на экран и определяем сумму.
            Console.WriteLine("Массив: ");
            for (int i = 0; i < array.Length; ++i)
            {
                array[i] = random.Next(-10, 30);
                Console.Write(array[i] + " ");
                if (array[i] >= 0)
                {
                    sum += array[i];
                }
            }

            return sum;
        }
    }
}
