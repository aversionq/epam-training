using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksClassLibrary
{
    public class Doubler
    {
        public static string DoubleChars()
        {
            Console.WriteLine("Введите первую строку: ");
            string inputStrFirst = Console.ReadLine();
            Console.WriteLine("Введите вторую строку: ");
            string inputStrSecond = Console.ReadLine();
            StringBuilder extendedStr = new StringBuilder();

            string uniqueChars = StringUniqueChars(inputStrSecond);
            for (int i = 0; i < inputStrFirst.Length; ++i)
            {
                foreach (var ch in uniqueChars)
                {
                    if (inputStrFirst[i].Equals(ch))     // Если в первой строке нашёлся символ из второй строки.
                    {
                        extendedStr.Append(inputStrFirst[i]);
                    }
                }
                extendedStr.Append(inputStrFirst[i]);
            }

            return extendedStr.ToString();
        }

        private static string StringUniqueChars(string str)
        {
            StringBuilder uniqueChars = new StringBuilder();
            foreach(var ch in str)
            {
                if (!uniqueChars.ToString().Contains(ch))
                {
                    uniqueChars.Append(ch);
                }
            }

            return uniqueChars.ToString();
        }
    }
}
