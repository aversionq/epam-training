using System;
using System.Threading;
using FileManagerClassLibrary;

namespace Task_4._1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            FileManager fileManager = new FileManager(@"G:\Мой диск\FileManagerDir");
            fileManager.Run();
        }
    }
}
