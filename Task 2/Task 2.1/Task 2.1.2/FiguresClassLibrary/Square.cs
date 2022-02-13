using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresClassLibrary
{
    public class Square : Figure
    {
        public double Side1 { get; set; }

        public Square(double side)
        {
            this.Side1 = side;
        }
        public virtual double GetPerimeter() => Side1 * 4;

        public virtual double GetArea() => Math.Pow(Side1, 2);

        public override string ToString()
        {
            return $"Квадрат со стороной = {Side1}. Периметр = {this.GetPerimeter()}," +
                $" площадь = {this.GetArea()}";
        }
    }
}
