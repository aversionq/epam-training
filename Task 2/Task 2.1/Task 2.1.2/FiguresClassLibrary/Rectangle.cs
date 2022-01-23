using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresClassLibrary
{
    public class Rectangle : Square
    {
        public double Side2 { get; set; }

        public Rectangle(double side1, double side2) : base(side1)
        {
            this.Side2 = side2;
        }

        public override double GetPerimeter() => Side1 * 2 + Side2 * 2;

        public override double GetArea() => Side1 * Side2;

        public override string ToString()
        {
            return $"Прямоугольник со сторонами {Side1} и {Side2}. Периметр = {this.GetPerimeter()}," +
                $" площадь = {this.GetArea()}";
        }
    }
}
