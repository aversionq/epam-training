using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresClassLibrary
{
    public class Circle : Point
    {
        public (double, double) Center { get; }
        private double _radius;

        public double Radius
        {
            get => this._radius;

            set
            {
                if (value > 0)
                {
                    this._radius = value;
                }
                else
                {
                    throw new ArgumentException($"{value} - недопустимое значение.");
                }
            }
        }

        public double Length { get => 2 * Math.PI * this.Radius; }

        public Circle(double x, double y, double radius) : base(x, y)
        {
            this.Radius = radius;
            this.Center = (this.X, this.Y);
        }

        public override string ToString()
        {
            return $"Окружность с центром в {this.Center} и с радиусом = {this.Radius}. Длина окружности = {this.Length}";
        }
    }
}
