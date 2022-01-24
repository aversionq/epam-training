using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClassLibrary
{
    public class GameSetup
    {
        public static void Run()
        {
            Random random = new Random();

            PlayingField playingField = new PlayingField(20, 20);
            Player player = new Player(random.Next(1, playingField.Field.GetLength(0) - 2), random.Next(1, playingField.Field.GetLength(1) - 2));

            List<GameCharacter> enemies = new List<GameCharacter>()
            {
                new Vampire(random.Next(1, playingField.Field.GetLength(0) - 2), random.Next(1, playingField.Field.GetLength(1) - 2)),
                new Zombie(random.Next(1, playingField.Field.GetLength(0) - 2), random.Next(1, playingField.Field.GetLength(1) - 2)),
                new Zombie(random.Next(1, playingField.Field.GetLength(0) - 2), random.Next(1, playingField.Field.GetLength(1) - 2)),
                new Vampire(random.Next(1, playingField.Field.GetLength(0) - 2), random.Next(1, playingField.Field.GetLength(1) - 2))
            };

            List<Bonus> bonuses = new List<Bonus>()
            {
                new Snickers(random.Next(1, playingField.Field.GetLength(0) - 2), random.Next(1, playingField.Field.GetLength(1) - 2)),
                new Juice(random.Next(1, playingField.Field.GetLength(0) - 2), random.Next(1, playingField.Field.GetLength(1) - 2)),
                new Snickers(random.Next(1, playingField.Field.GetLength(0) - 2), random.Next(1, playingField.Field.GetLength(1) - 2))
            };

            List<Barrier> barriers = new List<Barrier>();
            for (int i = 0; i < 4; ++i)
            {
                barriers.Add(new Barrier(random.Next(1, playingField.Field.GetLength(0) - 2), random.Next(1, playingField.Field.GetLength(1) - 2)));
            }

            playingField.Field = PlayingFieldHelper.MakeField(playingField.Field, player, enemies, bonuses, barriers, '-', '|');
            playingField.DrawField(player);
            while(!PlayingFieldHelper.GameOverCheck(playingField.Field, player, bonuses, enemies, barriers))
            {
                PlayingFieldHelper.CharacterMovement(playingField.Field, player, enemies);
                Console.Clear();
                playingField.Field = PlayingFieldHelper.MakeField(playingField.Field, player, enemies, bonuses, barriers, '-', '|');
                playingField.DrawField(player);
            }
        }
    }
}
