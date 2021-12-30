using System;

namespace TasksClassLibrary
{
    public class AverageWordAmount
    {
        public static double Averages()
        {
            Console.WriteLine("Введите строку: ");
            string inputStr = Console.ReadLine();
            string[] punctuationSigns = { ",", ".", ":", "!", "?", "-", ";" };

            foreach(var ch in punctuationSigns)
            {
                inputStr = inputStr.Replace(ch, " ");
            }

            var splitedText = inputStr.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            double sumOfLen = 0;
            for (int i = 0; i < splitedText.Length; ++i)
            {
                sumOfLen += splitedText[i].Length;
            }

            return Math.Round(sumOfLen / splitedText.Length);       // Округление средней длины слова.
        }
    }
}
