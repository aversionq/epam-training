using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileManagerClassLibrary
{
    internal class FileBackupper : IBackuppable
    {
        // Массив с путями всех доступных бэкапов.
        private static string[] _backups = Directory.GetDirectories(FileManagerHelper.BackupDir);

        public FileBackupper(string dir)
        {
            if (!Directory.Exists(dir))
            {
                throw new DirectoryNotFoundException("Directory not found!");
            }
            else
            {
                FileManagerHelper.WorkingDir = dir;
            }
        }

        public void StartBackup()
        {
            int choice = GetBackupNumber();
            ClearDirectory(FileManagerHelper.WorkingDir);   // Чистим рабочую директорию.
            // Копируем в рабочую директорию нужный бэкап.
            FileManagerHelper.CreateDirectoryCopy(_backups[choice], FileManagerHelper.WorkingDir);
        }

        // Метод выводит на экран пользователя список доступных бэкапов.
        private void ShowAvailableBackups()
        {
            if (_backups.Length > 1)
            {
                for (int i = 0; i < _backups.Length; i++)
                {
                    Console.WriteLine($"{i + 1}: {new DirectoryInfo(_backups[i]).Name}");
                }
            }
            else
            {
                throw new Exception("There are no available backups.");
            }
        }

        // С помощью этого метода получаем номер бэкапа, к которому нжно вернуться в рабочей директории.
        private int GetBackupNumber()
        {
            Console.WriteLine("Choose number of version you want to go back to");
            ShowAvailableBackups();

            string inputNum = Console.ReadLine();
            bool res = int.TryParse(inputNum, out int choice);

            if (res)
            {
                return choice - 1;
            }
            throw new ArgumentException("Wrong input.");
        }

        // Метод очистки директории.
        private void ClearDirectory(string path)
        {
            DirectoryInfo dirToClear = new DirectoryInfo(path);

            foreach (FileInfo file in dirToClear.GetFiles())
            {
                file.Delete();
            }

            foreach (DirectoryInfo dir in dirToClear.GetDirectories())
            {
                dir.Delete(true);
            }
        }
    }
}
