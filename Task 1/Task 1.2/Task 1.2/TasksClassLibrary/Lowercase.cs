using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksClassLibrary
{
    public class Lowercase
    {
        public static int CountLowercaseWords()
        {
            Console.WriteLine("Введите строку: ");
            string inputStr = Console.ReadLine();
            string[] punctuationSigns = { ",", ".", ":", "!", "?", "-", ";" };

            foreach (var ch in punctuationSigns)
            {
                inputStr = inputStr.Replace(ch, " ");
            }
            var splitedText = inputStr.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            int lowercaseCount = 0;
            foreach(var word in splitedText)
            {
                if (word.Equals(word.ToLower()))
                {
                    lowercaseCount++;
                }
            }

            return lowercaseCount;
        }
    }
}
