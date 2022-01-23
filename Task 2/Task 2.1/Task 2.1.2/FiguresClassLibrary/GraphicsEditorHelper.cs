using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresClassLibrary
{
    class GraphicsEditorHelper
    {
        private enum FigureType : byte
        {
            // None = 0,
            Circle = 1,
            Round = 2,
            Ring = 3,
            Line = 4,
            Square = 5,
            Rectangle = 6,
            Triangle = 7
        }

        private static Circle CreateCircle()
        {
            double x, y;
            double r;
            Console.WriteLine("Введите координаты центра окружности: ");
            Console.WriteLine("x: ");
            x = Double.Parse(Console.ReadLine());
            Console.WriteLine("y: ");
            y = Double.Parse(Console.ReadLine());
            Console.WriteLine("Введите радиус окружности: ");
            r = Double.Parse(Console.ReadLine());

            return new Circle(x, y, r);
        }

        private static Round CreateRound()
        {
            double x, y;
            double r;
            Console.WriteLine("Введите координаты центра круга: ");
            Console.WriteLine("x: ");
            x = Double.Parse(Console.ReadLine());
            Console.WriteLine("y: ");
            y = Double.Parse(Console.ReadLine());
            Console.WriteLine("Введите радиус круга: ");
            r = Double.Parse(Console.ReadLine());

            return new Round(x, y, r);
        }

        private static Ring CreateRing()
        {
            double x, y;
            double inR, outR;
            Console.WriteLine("Введите координаты центра кольца: ");
            Console.WriteLine("x: ");
            x = Double.Parse(Console.ReadLine());
            Console.WriteLine("y: ");
            y = Double.Parse(Console.ReadLine());
            Console.WriteLine("Введите внутренний радиус кольца: ");
            inR = Double.Parse(Console.ReadLine());
            Console.WriteLine("Введите внешний радиус кольца: ");
            outR = Double.Parse(Console.ReadLine());

            return new Ring(x, y, inR, outR);
        }

        private static Line CreateLine()
        {
            double x1, y1, x2, y2;
            Console.WriteLine("Введите первую точку: ");
            Console.WriteLine("x1: ");
            x1 = Double.Parse(Console.ReadLine());
            Console.WriteLine("y1: ");
            y1 = Double.Parse(Console.ReadLine());

            Console.WriteLine("Введите вторую точку: ");
            Console.WriteLine("x2: ");
            x2 = Double.Parse(Console.ReadLine());
            Console.WriteLine("y2: ");
            y2 = Double.Parse(Console.ReadLine());

            return new Line(x1, y1, x2, y2);
        }

        private static Square CreateSquare()
        {
            double side;
            Console.WriteLine("Введите длину стороны квадрата: ");
            side = Double.Parse(Console.ReadLine());

            return new Square(side);
        }

        private static Rectangle CreateRectangle()
        {
            double side1, side2;
            Console.WriteLine("Введите длину первой стороны прямоугольника: ");
            side1 = Double.Parse(Console.ReadLine());
            Console.WriteLine("Введите длину второй стороны прямоугольника: ");
            side2 = Double.Parse(Console.ReadLine());

            return new Rectangle(side1, side2);
        }

        private static Triangle CreateTriangle()
        {
            double side1, side2, side3;
            Console.WriteLine("Введите длину первой стороны треугольника: ");
            side1 = Double.Parse(Console.ReadLine());
            Console.WriteLine("Введите длину второй стороны треугольника: ");
            side2 = Double.Parse(Console.ReadLine());
            Console.WriteLine("Введите длину третьей стороны треугольника: ");
            side3 = Double.Parse(Console.ReadLine());

            return new Triangle(side1, side2, side3);
        }

        private static Figure ChooseFigure()
        {
            string choice = Console.ReadLine();
            FigureType fType;
            bool res = Enum.TryParse(choice, out fType);
            switch (fType)
            {
                case FigureType.Circle:
                    return CreateCircle();
                case FigureType.Round:
                    return CreateRound();
                case FigureType.Ring:
                    return CreateRing();
                case FigureType.Line:
                    return CreateLine();
                case FigureType.Square:
                    return CreateSquare();
                case FigureType.Rectangle:
                    return CreateRectangle();
                case FigureType.Triangle:
                    return CreateTriangle();
                default:
                    throw new ArgumentException("Неизвестная фигура.");
            }
        }

        public static int ChooseAction()
        {
            Console.WriteLine(Environment.NewLine + "Выберите действие: " + Environment.NewLine +
                "1. Добавить фигуру" + Environment.NewLine +
                "2. Вывести фигуры" + Environment.NewLine +
                "3. Очистить холст" + Environment.NewLine +
                "4. Выход");

            int choice;
            bool res;
            do
            {
                res = Int32.TryParse(Console.ReadLine(), out choice);
                if (choice < 0 && choice > 4 && !res)   // Проверка на случай первой итерации.
                {
                    Console.WriteLine("Введите валидное значение.");
                }
            } while (choice < 0 && choice > 4 && !res);

            return choice;
        }

        public static Figure CreateFigure()
        {
            Console.WriteLine(Environment.NewLine + "Выберите фигуру, которую вы хотите создать:");
            foreach (var t in FigureType.GetNames(typeof(FigureType)))
            {
                Console.WriteLine($"{t}");
            }
            Console.WriteLine();

            return ChooseFigure();
        }
    }
}
