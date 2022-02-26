using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayExtensionsClassLibrary
{
    public static class DigitsArrayExtensions
    {
        public static void ForEach<T>(this T[] array, Func<T, T> method) where T : struct
        {
            if (method == null)
            {
                return;
            }

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = method.Invoke(array[i]);
            }
        }

        public static int ExtensionsSum(this int[] array) => array.Sum();

        public static double ExtensionsSum(this double[] array) => array.Sum();

        public static float ExtensionsSum(this float[] array) => array.Sum();

        public static double ExtensionsAverage(this int[] array) => array.Average();

        public static double ExtensionsAverage(this double[] array) => array.Average();

        public static double ExtensionsAverage(this float[] array) => array.Average();

        public static T MostFrequentElement<T>(this T[] array) where T : struct
        {
            return array.GroupBy(x => x).OrderByDescending(x => x.Count()).FirstOrDefault().Key;
        }
    }
}
