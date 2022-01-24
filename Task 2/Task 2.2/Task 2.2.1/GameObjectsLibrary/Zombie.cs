using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClassLibrary
{
    public class Zombie : GameCharacter, IEnemy
    {
        public Zombie(int x, int y) : base(x, y)
        {
            this.name = 'Z';
        }

        public override void Move(char[,] field)
        {
            Random random = new Random();
            int incX;
            int incY;
            do
            {
                incX = random.Next(-1, 2);
                incY = random.Next(-1, 2);
            } while ((this.coords.Item1 + incX) >= (field.GetLength(0) - 2) || (this.coords.Item2 + incY) >= (field.GetLength(1) - 2)
            || (this.coords.Item1 + incX) <= 1 || (this.coords.Item2 + incY) <= 1);     // Избегаем выход монстра за пределы карты.
            this.coords.Item1 += incX;
            this.coords.Item2 += incY;
        }
    }
}
