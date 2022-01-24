using System;
using GameClassLibrary;

namespace Task_2._2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Обозначения:" + Environment.NewLine + "P - Player (игрок), вы играете за него" 
                + Environment.NewLine + "Z - Zombie, это вражеское существо" + Environment.NewLine
                +"V - Vampire, ещё один вражеский юнит" + Environment.NewLine +
                "S - Snickers, это один из бонусов, восстанавливает 10 очков здоровья игрока"
                + Environment.NewLine + "J - Juice, бонус, который восстанавливает игроку 15 очков здоровья"
                + Environment.NewLine + "/ - Препятствие." + Environment.NewLine + "Правила игры:" + Environment.NewLine +
                "Одержать победу можно только собрав все бонусы на карте. При столкновении с препятствием, вражеским юнитом" +
                " и границей игрового поля будет поражение. Так же проигрыш будет в том случае, если очков здоровья у игрока" +
                " станет меньше или равно 0. За каждый шаг игрок теряет 2 очка здоровья. Управление стандартное - WASD." 
                + Environment.NewLine + "Для начала игры нажмите любую кнопку:");
            Console.ReadKey();
            Console.Clear();
            GameSetup.Run();
        }
    }
}
