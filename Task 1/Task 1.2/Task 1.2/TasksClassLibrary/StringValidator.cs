using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksClassLibrary
{
    public class StringValidator
    {
        public static string Validator()
        {
            Console.WriteLine("Введите строку: ");
            string inputStr = Console.ReadLine();
            var signOrder = GetEndSigns(inputStr);
            char[] separators = new char[] { '.', '!', '?' };

            var sentences = inputStr.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < sentences.Length; ++i)
            {
                if (sentences[i][0].Equals(' '))
                {
                    sentences[i] = sentences[i].Insert(1, Char.ToUpper(sentences[i][1]).ToString());
                    sentences[i] = sentences[i].Remove(2, 1);
                }
                else
                {
                    sentences[i] = sentences[i].Insert(0, Char.ToUpper(sentences[i][0]).ToString());
                    sentences[i] = sentences[i].Remove(1, 1);
                }
            }

            return JoinValidString(sentences, signOrder);
        }

        private static string GetEndSigns(string text)
        {
            StringBuilder signs = new StringBuilder();

            for (int i = 0; i < text.Length; ++i)
            {
                if (text[i].Equals('!') || text[i].Equals('?') || text[i].Equals('.'))
                {
                    signs.Append(text[i]);
                }
            }

            return signs.ToString();
        }

        private static string JoinValidString(string[] sentences, string signs)
        {
            string validString = "";
            for (int i = 0; i < signs.Length; ++i)
            {
                switch (signs[i])
                {
                    case '!':
                        validString += sentences[i] + "!";
                        break;

                    case '?':
                        validString += sentences[i] + "?";
                        break;

                    case '.':
                        validString += sentences[i] + ".";
                        break;

                    default:
                        break;
                }
            }

            return validString;
        }
    }
}
