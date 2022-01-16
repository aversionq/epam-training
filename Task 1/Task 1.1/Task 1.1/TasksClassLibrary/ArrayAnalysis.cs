using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksClassLibrary
{
    public class ArrayAnalysis
    {
        private static void SortArray(int[] arr)      // Сортировка вставками.
        {
            for (int i = 0; i < arr.Length; ++i)
            {
                int cur = arr[i];
                int j = i;
                while (j > 0 && cur < arr[j - 1])
                {
                    arr[j] = arr[j - 1];
                    --j;
                }
                arr[j] = cur;
            }
        }

        private static int FindArrayMax(int[] arr)
        {
            int max = arr[0];
            for (int i = 0; i < arr.Length; ++i)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }

            return max;
        }

        private static int FindArrayMin(int[] arr)
        {
            int min = arr[0];
            for (int i = 0; i < arr.Length; ++i)
            {
                if (arr[i] < min)
                {
                    min = arr[i];
                }
            }

            return min;
        }

        private static int[] GetRandomArray(int size, int minPossible, int maxPossible)
        {
            int[] arr = new int[size];
            Random random = new Random();

            for (int i = 0; i < size; ++i)
            {
                arr[i] = random.Next(minPossible, maxPossible);
            }

            return arr;
        }

        private static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; ++i)
            {
                Console.Write(arr[i] + " ");
            }
        }

        public static void ArrayProcessing()
        {
            int[] array = GetRandomArray(10, -100, 100);
            Console.Write("Изначальный массив: ");
            PrintArray(array);
            Console.Write("\nОтсортированный массив: ");
            SortArray(array);
            PrintArray(array);
            Console.Write("\nМаксимальное значение в массиве: ");
            Console.Write(FindArrayMax(array));
            Console.Write("\nМинимальное значение в массиве: ");
            Console.Write(FindArrayMin(array));
        }
    }
}
