using System;

namespace TasksClassLibrary
{
    public class CountArea
    {
        public static void Rectangle()
        {
            string inputNum;
            double a, b;
            bool inputCheckA, inputCheckB;

            Console.Write("Введите сторону a: ");
            inputNum = Console.ReadLine();
            inputCheckA = Double.TryParse(inputNum, out a);

            Console.Write("Введите сторону b: ");
            inputNum = Console.ReadLine();
            inputCheckB = Double.TryParse(inputNum, out b);

            if (inputCheckA && inputCheckB && a > 0 && b > 0)
            {
                Console.WriteLine($"Площадь прямоугольника = {a * b}");
            }
            else
            {
                Console.WriteLine("Введены некорректные данные.");
            }
        }
    }
}
