using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresClassLibrary
{
    public class Triangle : Figure
    {
        public double Side1 { get; init; }
        public double Side2 { get; init; }
        public double Side3 { get; init; }
        private double semiPerimeter;

        public Triangle(double s1, double s2, double s3)
        {
            this.Side1 = s1;
            this.Side2 = s2;
            this.Side3 = s3;
            this.semiPerimeter = (s1 + s2 + s3) / 2;
        }

        public double GetPerimeter() => Side1 + Side2 + Side3;

        public double GetArea()
        {
            return Math.Sqrt(semiPerimeter * (semiPerimeter - Side1) * 
                (semiPerimeter - Side2) * (semiPerimeter - Side3));
        }

        public override string ToString()
        {
            return $"Треугольник со сторонами {Side1}, {Side2} и {Side3}. Периметр = {this.GetPerimeter()}," +
                $"площадь = {this.GetArea()}";
        }
    }
}
