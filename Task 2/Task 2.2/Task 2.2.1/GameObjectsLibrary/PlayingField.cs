using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClassLibrary
{
    public class PlayingField
    {
        private int width;
        private int height;
        public char[,] Field { get; set; }

        public PlayingField(int w, int h)
        {
            this.width = w;
            this.height = h;
            this.Field = new char[h, w];
        }

        public void DrawField(Player player)
        {
            for (int i = 0; i < this.height; ++i)
            {
                for (int j = 0; j < this.width; ++j)
                {
                    Console.Write(this.Field[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Текущее количество очков здоровья игрока: {player.healthPoints}");
        }
    }
}
