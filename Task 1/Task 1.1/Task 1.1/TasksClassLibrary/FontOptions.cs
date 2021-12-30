using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksClassLibrary
{
    public class FontOptions
    {
        public static void FontAdjustment()
        {
            int userChoice;
            string inputNum;
            List<string> options = new List<string>();

            PrintMenuString(options);
            inputNum = Console.ReadLine();
            bool parseRes = Int32.TryParse(inputNum, out userChoice);

            while (parseRes)
            {
                switch(userChoice)
                {
                    case 1:
                        ChangeAdjustments(options, "Bold");
                        break;

                    case 2:
                        ChangeAdjustments(options, "Italic");
                        break;

                    case 3:
                        ChangeAdjustments(options, "Underline");
                        break;

                    default:
                        return;
                }
                PrintMenuString(options);
                inputNum = Console.ReadLine();
                parseRes = Int32.TryParse(inputNum, out userChoice);
            }
            Console.WriteLine("Введены некорректные данные.");
        }

        private static void PrintMenuString(List<string> adjs)
        {
            if (adjs.Count == 0)
            {
                Console.WriteLine("Параметры: None\nВведите:\n\t1: bold\n\t2: italic\n\t3: underline\n\t4: Закончить настройку");
            }
            else
            {
                string adjsString = String.Join(", ", adjs);
                Console.WriteLine("Параметры: " + adjsString + "\nВведите:\n\t1: bold\n\t2: italic\n\t3: underline\n\t4: Закончить настройку");
            }
            
        }

        private static void ChangeAdjustments(List<string> adjs, string adjustment)
        {
            if (adjs.Contains(adjustment))
            {
                adjs.Remove(adjustment);
            }
            else
            {
                adjs.Add(adjustment);
            }
        }
    }
}
