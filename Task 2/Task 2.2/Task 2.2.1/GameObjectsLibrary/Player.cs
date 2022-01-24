using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClassLibrary
{
    public class Player : GameCharacter
    {
        internal int healthPoints;
        public Player(int x, int y) : base(x, y)
        {
            this.healthPoints = 100;
            this.name = 'P';
        }

        public override void Move()
        {
            ConsoleKey key = Console.ReadKey().Key;
            switch (key)
            {
                case ConsoleKey.W:
                    this.coords.Item1 -= 1;
                    this.healthPoints -= 2;
                    break;
                case ConsoleKey.A:
                    this.coords.Item2 -= 1;
                    this.healthPoints -= 2;
                    break;
                case ConsoleKey.S:
                    this.coords.Item1 += 1;
                    this.healthPoints -= 2;
                    break;
                case ConsoleKey.D:
                    this.coords.Item2 += 1;
                    this.healthPoints -= 2;
                    break;
                default:
                    break;
            }
        }
    }
}
