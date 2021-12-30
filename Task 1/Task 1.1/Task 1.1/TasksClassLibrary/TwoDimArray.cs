using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksClassLibrary
{
    public class TwoDimArray
    {
        private static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                for (int j = 0; j < matrix.GetLength(1); ++j)
                {
                    Console.Write(String.Format("{0, 6}", matrix[i, j]));
                }
                Console.WriteLine();
            }
        }

        // 2D Array task.
        public static int SumOfEven()
        {
            int sum = 0;
            int[,] matrix = new int[3, 3];
            Random random = new Random();

            // Заполняем матрицу.
            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                for (int j = 0; j < matrix.GetLength(1); ++j)
                {
                    matrix[i, j] = random.Next(-50, 50);
                }
            }

            Console.WriteLine("Матрица: ");
            PrintMatrix(matrix);

            // Считаем сумму.
            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                for (int j = 0; j < matrix.GetLength(1); ++j)
                {
                    if ((i + j) % 2 == 0)
                    {
                        sum += matrix[i, j];
                    }
                }
            }

            return sum;
        }
    }
}
