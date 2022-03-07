using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3._1._2
{
    class TextHandler
    {
        public static void AnalyseText()
        {
            Dictionary<string, int> wordsAmountDict = new Dictionary<string, int>();
            string text;

            text = InputText();
            CountRepetitions(wordsAmountDict, text);

            string numInput;
            int repetitionsNum;
            bool checkInput;

            Console.WriteLine(Environment.NewLine + "What's your maximum number of word repetitions? Input it here: ");
            numInput = Console.ReadLine();
            checkInput = Int32.TryParse(numInput, out repetitionsNum);

            Console.WriteLine();
            if (checkInput)
            {
                foreach (var item in wordsAmountDict)
                {
                    if (item.Value > repetitionsNum)
                    {
                        Console.WriteLine($"Word '{item.Key}' repeats {item.Value} times. It's too much.");
                    }
                }
                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine("Full list of word repetitions:");
                PrintPairs(wordsAmountDict);
            }
            else
            {
                throw new ArgumentException("Wrong input.");
            }
        }

        private static string InputText()
        {
            Console.WriteLine("Input your text here: ");
            return Console.ReadLine();
        }

        private static Dictionary<string, int> CountRepetitions(Dictionary<string, int> wordsAmountDict, string text)
        {
            string[] separators = { " ", ".", ",", ":", "?", "!", "/", ";", "(", ")" };

            string[] splittedText = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < splittedText.Length; i++)
            {
                splittedText[i] = splittedText[i].ToLower();
            }

            foreach (var item in splittedText)
            {
                if (wordsAmountDict.ContainsKey(item))
                {
                    wordsAmountDict[item]++;
                }
                else
                {
                    wordsAmountDict.Add(item, 1);
                }
            }

            return wordsAmountDict;
        }

        private static void PrintPairs(Dictionary<string, int> wordsAmountDict)
        {
            foreach (var item in wordsAmountDict)
            {
                Console.WriteLine($"Word: {item.Key, 12} | Repetitions: {item.Value}");
            }
        }
    }
}
