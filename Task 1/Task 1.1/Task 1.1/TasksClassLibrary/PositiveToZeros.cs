using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksClassLibrary
{
    public class PositiveToZeros
    {
        private static void PrintThreeDimArray(int[,,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); ++i)
            {
                for (int j = 0; j < arr.GetLength(1); ++j)
                {
                    for (int k = 0; k < arr.GetLength(2); ++k)
                    {
                        Console.Write(String.Format("{0, 6}", arr[i, j, k] + " "));
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }

        public static void NoPositive()
        {
            int[,,] threeDimArray = new int[3, 3, 3];
            Random random = new Random();

            // Заполняем массив.
            for (int i = 0; i < threeDimArray.GetLength(0); ++i)
            {
                for (int j = 0; j < threeDimArray.GetLength(1); ++j)
                {
                    for (int k = 0; k < threeDimArray.GetLength(2); ++k)
                    {
                        threeDimArray[i, j, k] = random.Next(-100, 100);
                    }
                }
            }
            Console.WriteLine("Изначальный массив: ");
            PrintThreeDimArray(threeDimArray);

            // Заменяем положительные элементы на нули.
            for (int i = 0; i < threeDimArray.GetLength(0); ++i)
            {
                for (int j = 0; j < threeDimArray.GetLength(1); ++j)
                {
                    for (int k = 0; k < threeDimArray.GetLength(2); ++k)
                    {
                        if (threeDimArray[i, j, k] > 0)
                        {
                            threeDimArray[i, j, k] = 0;
                        }
                    }
                }
            }
            Console.WriteLine("Изменённый массив: ");
            PrintThreeDimArray(threeDimArray);
        }
    }
}
