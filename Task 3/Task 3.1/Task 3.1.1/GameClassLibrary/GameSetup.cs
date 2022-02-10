using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClassLibrary
{
    public class GameSetup
    {
        private static List<Player> players;

        public static void Start()
        {
            InitPlayers();
            Elimination();
        }

        private static void InitPlayers()
        {
            string numInput;
            int playersAmount;
            bool checkInput;

            Console.WriteLine("Введите количество игроков: ");
            numInput = Console.ReadLine();
            checkInput = Int32.TryParse(numInput, out playersAmount);

            if (checkInput)
            {
                players = new List<Player>();
                for (int i = 0; i < playersAmount; ++i)
                {
                    players.Add(new Player(i + 1));
                }
            }
            else
            {
                throw new ArgumentException("Wrong input.");
            }
        }

        private static void Elimination()
        {
            string elimNumInput;
            int elimNum;
            int roundNum = 1;
            bool checkInput;

            Console.WriteLine("Введите, какой по счету человек будет вычеркнут каждый раунд: ");
            elimNumInput = Console.ReadLine();
            checkInput = Int32.TryParse(elimNumInput, out elimNum);

            if (checkInput)
            {
                while (players.Count >= elimNum)
                {
                    players.RemoveAt(elimNum - 1);
                    Console.WriteLine($"Раунд {roundNum}. Вычеркнут человек. Людей осталось: {players.Count}");
                    roundNum++;
                }
                Console.WriteLine("Игра окончена. Невозможно вычеркнуть больше людей.");
            }
            else
            {
                throw new ArgumentException("Wrong input.");
            }
        }
    }
}
