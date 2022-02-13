using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClassLibrary
{
    public class Snickers : Bonus
    {
        public Snickers(int x, int y) : base(x, y)
        {
            this.name = 'S';
            this.healAmount = 10;
        }

        public override void Heal(Player player)
        {
            player.healthPoints += this.healAmount;
        }
    }
}
