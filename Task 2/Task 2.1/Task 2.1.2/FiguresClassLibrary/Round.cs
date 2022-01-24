using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresClassLibrary
{
    public class Round : Circle
    {
        public double Area { get => Math.PI * Math.Pow(this.Radius, 2); }

        public Round(double x, double y, double r) : base(x, y, r) { }

        public override string ToString()
        {
            return $"Круг с центром в {this.Center} и с радиусом = {this.Radius}. Длина круга = {this.Length}, площадь круга = {this.Area}";
        }
    }
}
