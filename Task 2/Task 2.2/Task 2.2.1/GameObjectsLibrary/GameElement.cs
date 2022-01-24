using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClassLibrary
{
    public abstract class GameElement
    {
        internal char name;
        internal (int, int) coords;
        protected GameElement(int x, int y)
        {
            this.coords.Item1 = x;
            this.coords.Item2 = y;
        }
    }
}
