using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Task_3._3._2
{
    static class StringExtensions
    {
        private static Regex English = new Regex(@"[a-zA-Z]");
        private static Regex Russian = new Regex(@"[Ёёа-яА-Я]");
        private static Regex Number = new Regex(@"[0-9]");

        public enum Language
        {
            None = 0,
            English = 1,
            Russian = 2,
            Number = 3,
            Mixed = 4
        }

        public static Language DefineLanguage(this string str)
        {
            if (English.IsMatch(str) && Russian.IsMatch(str) ||
                English.IsMatch(str) && Number.IsMatch(str) ||
                Russian.IsMatch(str) && Number.IsMatch(str))
            {
                return Language.Mixed;
            }
            else if (English.IsMatch(str))
            {
                return Language.English;
            }
            else if (Russian.IsMatch(str))
            {
                return Language.Russian;
            }
            else if (Number.IsMatch(str))
            {
                return Language.Number;
            }
            else
            {
                return Language.None;
            }
        }
    }
}
