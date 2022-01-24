using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClassLibrary
{
    public abstract class GameObject : GameElement
    {
        protected GameObject(int x, int y) : base(x, y) { }
    }
}
