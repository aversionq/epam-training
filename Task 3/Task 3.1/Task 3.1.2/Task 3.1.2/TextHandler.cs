using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3._1._2
{
    class TextHandler
    {
        private static string _text;
        private static Dictionary<string, int> _wordsAmountDict;
        private static string[] separators = { " ", ".", ",", ":", "?", "!", "/", ";", "(", ")" };

        public static void AnalyseText()
        {
            InputText();
            CountRepetitions();

            string numInput;
            int repetitionsNum;
            bool checkInput;

            Console.WriteLine(Environment.NewLine + "What's your maximum number of word repetitions? Input it here: ");
            numInput = Console.ReadLine();
            checkInput = Int32.TryParse(numInput, out repetitionsNum);

            Console.WriteLine();
            if (checkInput)
            {
                foreach (var item in _wordsAmountDict)
                {
                    if (item.Value > repetitionsNum)
                    {
                        Console.WriteLine($"Word '{item.Key}' repeats {item.Value} times. It's too much.");
                    }
                }
                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine("Full list of word repetitions:");
                PrintPairs();
            }
            else
            {
                throw new ArgumentException("Wrong input.");
            }
        }

        private static void InputText()
        {
            Console.WriteLine("Input your text here: ");
            _text = Console.ReadLine();
        }

        private static void CountRepetitions()
        {
            _wordsAmountDict = new Dictionary<string, int>();

            string[] splittedText = _text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < splittedText.Length; i++)
            {
                splittedText[i] = splittedText[i].ToLower();
            }

            foreach (var item in splittedText)
            {
                if (_wordsAmountDict.ContainsKey(item))
                {
                    _wordsAmountDict[item]++;
                }
                else
                {
                    _wordsAmountDict.Add(item, 1);
                }
            }
        }

        private static void PrintPairs()
        {
            foreach (var item in _wordsAmountDict)
            {
                Console.WriteLine($"Word: {item.Key, 12} | Repetitions: {item.Value}");
            }
        }
    }
}
