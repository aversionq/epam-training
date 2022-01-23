using System;
using FiguresClassLibrary;

namespace Task_2._1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle circle = new Circle(2, 3, 10);
            Console.WriteLine(circle);

            Round round = new Round(2, 3, 10);
            Console.WriteLine(round);

            Console.WriteLine(circle.Length);
            Console.WriteLine(round.Length);
            Console.WriteLine(round.Area);
            Console.WriteLine(circle.Center);

            Console.WriteLine("ring");
            Ring ring = new Ring(0, 0, 10, 14);
            Console.WriteLine(ring.Length);
            Console.WriteLine(ring.Area);
            Console.WriteLine(ring.Center);
            Console.WriteLine(ring.inner);
            Console.WriteLine(ring.outer);

            Console.WriteLine("line");
            Line line = new Line(0, 0, 3, 4);
            Console.WriteLine(line);

            Console.WriteLine("square");
            Square square = new Square(6.8567);
            Console.WriteLine(square.GetArea());

            Console.WriteLine("rect");
            Rectangle rectangle = new Rectangle(5, 4);
            Console.WriteLine(rectangle.GetPerimeter());

            Console.WriteLine("triangle");
            Triangle triangle = new Triangle(3, 4, 5);
            Console.WriteLine(triangle.GetArea());
        }
    }
}
