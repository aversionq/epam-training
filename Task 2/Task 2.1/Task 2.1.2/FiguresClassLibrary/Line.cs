using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresClassLibrary
{
    public class Line : Figure
    {
        public Point FirstPoint { get; set; }
        public Point SecondPoint { get; set; }
        public double Length
        {
            get => Math.Sqrt(Math.Pow(FirstPoint.X - SecondPoint.X, 2) + Math.Pow(FirstPoint.Y - SecondPoint.Y, 2));
        }

        public Line(double x1, double y1, double x2, double y2)
        {
            FirstPoint = new Point(x1, y1);
            SecondPoint = new Point(x2, y2);
        }

        public override string ToString()
        {
            return $"Линия, построенная по точкам {FirstPoint} и {SecondPoint}. Длина линии = {Length}.";
        }
    }
}
