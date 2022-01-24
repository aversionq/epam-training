using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClassLibrary
{
    class PlayingFieldHelper
    {
        private static void PlacePlayer(char[,] field, Player player)
        {
            field[player.coords.Item1, player.coords.Item2] = player.name;
        }

        private static void PlaceEnemy(char[,] field, List<GameCharacter> enemies)
        {
            foreach(var item in enemies)
            {
                field[item.coords.Item1, item.coords.Item2] = item.name;
            }
        }

        private static void PlaceBonuses(char[,] field, List<Bonus> bonuses)
        {
            foreach (var item in bonuses)
            {
                field[item.coords.Item1, item.coords.Item2] = item.name;
            }
        }

        private static void PlaceBarriers(char[,] field, List<Barrier> barriers)
        {
            foreach (var item in barriers)
            {
                field[item.coords.Item1, item.coords.Item2] = item.name;
            }
        }

        private static void BonusInteraction(Player player, List<Bonus> bonuses)
        {
            for (int i = bonuses.Count - 1; i >= 0; --i)
            {
                if (bonuses[i].coords.Item1 == player.coords.Item1 && bonuses[i].coords.Item2 == player.coords.Item2)
                {
                    bonuses[i].Heal(player);
                    bonuses.RemoveAt(i);
                }
            }
        }

        public static void CharacterMovement(char[,] field, Player player, List<GameCharacter> enemies)
        {
            player.Move();
            foreach(var item in enemies)
            {
                item.Move(field);
            }
        }

        public static char[,] MakeField(char[,] field, Player player, List<GameCharacter> enemies, 
            List<Bonus> bonuses,List<Barrier> barriers, char vertBounds, char horBounds)
        {
            for (int i = 0; i < field.GetLength(0); ++i)
            {
                for (int j = 0; j < field.GetLength(1); ++j)
                {
                    if (i == 0 || i == field.GetLength(0) - 1)
                    {
                        field[i, j] = vertBounds;
                    }
                    else if(j == 0 || j == field.GetLength(1) - 1)
                    {
                        field[i, j] = horBounds;
                    }
                    else
                    {
                        field[i, j] = ' ';
                    }
                }
            }

            PlacePlayer(field, player);
            PlaceBarriers(field, barriers);
            PlaceBonuses(field, bonuses);
            PlaceEnemy(field, enemies);

            BonusInteraction(player, bonuses);

            return field;
        }

        public static bool GameOverCheck(char[,] field, Player player, List<Bonus> bonuses,
            List<GameCharacter> enemies, List<Barrier> barriers)
        {
            if (player.coords.Item1 == 0 || player.coords.Item1 == field.GetLength(0) - 1
                || player.coords.Item2 == 0 || player.coords.Item2 == field.GetLength(1) - 1)
            {
                Console.Clear();
                Console.WriteLine("Вы покинули игровое поле." + Environment.NewLine + "Вы проиграли.");
                return true;
            }

            if (player.healthPoints <= 0)
            {
                Console.Clear();
                Console.WriteLine("У вас закончились очки здоровья." + Environment.NewLine + "Вы проиграли.");
                return true;
            }

            foreach (var item in enemies)
            {
                if (player.coords.Item1 == item.coords.Item1 && player.coords.Item2 == item.coords.Item2)
                {
                    Console.Clear();
                    Console.WriteLine("Вы были съедены монстром..." + Environment.NewLine + "Вы проиграли.");
                    return true;
                }
            }

            foreach (var item in barriers)
            {
                if (player.coords.Item1 == item.coords.Item1 && player.coords.Item2 == item.coords.Item2)
                {
                    Console.Clear();
                    Console.WriteLine("Вы врезались в препятствие." + Environment.NewLine + "Вы проиграли.");
                    return true;
                }
            }

            if (bonuses.Count > 0)
            {
                return false;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Вы собрали все бонусы!" + Environment.NewLine + "Победа!");
                return true;
            }
        }
    }
}
