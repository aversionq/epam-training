using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClassLibrary
{
    public abstract class Bonus : GameObject, IHealing
    {
        protected int healAmount;

        public Bonus(int x, int y) : base(x, y) { }

        public virtual void Heal(Player player) { }
    }
}
