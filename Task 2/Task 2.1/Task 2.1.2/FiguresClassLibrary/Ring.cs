using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresClassLibrary
{
    public class Ring : Figure
    {
        // Кольцо реализовано с помощью агрегации, так как оно является совокупностью 2 кругов.
        public Round inner;
        public Round outer;
        public (double, double) Center { get; }
        public double Area { get => outer.Area - inner.Area; }
        public double Length { get=> 2 * Math.PI * inner.Radius + 2 * Math.PI * outer.Radius; }

        public Ring(double x, double y, double inR, double outR)
        {
            this.inner = new Round(x, y, inR);
            this.outer = new Round(x, y, outR);
            this.Center = inner.Center;
        }

        public override string ToString()
        {
            return $"Кольцо с центром в {this.Center}, с внутренним радиусом = " +
                $"{this.inner.Radius} и внешним радиусом = {this.outer.Radius}. " +
                $"Сумма длин контуров кольца = {this.Length}, площадь кольца = {this.Area}";
        }
    }
}
