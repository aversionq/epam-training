using System;
using CustomStringLibrary;

namespace Task_2._1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Создаём экземпляр класса CharacterArray и выведем его на экран:");
            CharacterArray test = new CharacterArray("Aether");
            Console.WriteLine(test);
            Console.WriteLine();

            Console.WriteLine("Работа свойства Length:");
            Console.WriteLine(test.Length);
            Console.WriteLine();

            Console.WriteLine("Сделаем ещё один объект класса CharacterArray и посмотрим работу конкатенации:");
            CharacterArray test2 = new CharacterArray("Realm");
            test += test2;
            Console.WriteLine(test);
            Console.WriteLine();

            Console.WriteLine("Неявное приведение CharacterArray к string:");
            string str = (string)test;
            Console.WriteLine(str);
            Console.WriteLine();

            var test3 = new CharacterArray(new char[] { 'R', 'e', 'a', 'l', 'm'});
            Console.WriteLine("Операции сравнений, будем сравнивать:" + Environment.NewLine + $"test: {test}"
                + Environment.NewLine + $"test2: {test2}" + Environment.NewLine + $"test3: {test3}");
            Console.WriteLine("test == test2: " + $"{test == test2}");
            Console.WriteLine("test != test2: " + $"{test != test2}");
            Console.WriteLine("test2 == test3: " + $"{test2 == test3}");
            Console.WriteLine("test2 != test3: " + $"{test2 != test3}");
            Console.WriteLine();

            Console.WriteLine("Метод поиска символа:" + Environment.NewLine + $"В {test} будем искать букву 'e':");
            Console.WriteLine($"Первое вхождение: {test.IndexOf('e')}");
            Console.WriteLine($"Последнее вхождение: {test.LastIndexOf('e')}");
            Console.WriteLine();

            Console.WriteLine("Метод нахождения среднего арифметического символов по таблице Unicode:" +
                Environment.NewLine + "Сделаем новый объект класса:");
            var test4 = new CharacterArray("abz");
            Console.WriteLine(test4);
            Console.WriteLine($"Среднее арифметическое: {test4.Mean()}");
            Console.WriteLine();

            Console.WriteLine("Работа индексаторов:");
            Console.WriteLine(test4);
            Console.WriteLine("Заменим символ с индексом 1 на 'q':");
            test4[1] = 'q';
            Console.WriteLine($"Выведем на экран изменённый символ объекта: {test4[1]}");
            Console.WriteLine(test4);
        }
    }
}
