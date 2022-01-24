using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClassLibrary
{
    class Juice : Bonus
    {
        public Juice(int x, int y) : base(x, y)
        {
            this.name = 'J';
            this.healAmount = 15;
        }

        public override void Heal(Player player)
        {
            player.healthPoints += this.healAmount;
        }
    }
}
