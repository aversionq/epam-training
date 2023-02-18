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
        private FileManagerHelper fileManagerHelper = new FileManagerHelper();

        // Массив с путями всех доступных бэкапов.
        private string[] _backups;

        public FileBackupper(string dir, string backupDir)
        {
            if (!Directory.Exists(dir))
            {
                throw new DirectoryNotFoundException("Directory not found!");
            }
            else
            {
                fileManagerHelper.WorkingDir = dir;
                fileManagerHelper.BackupDir = backupDir;
                _backups = Directory.GetDirectories(fileManagerHelper.BackupDir);
                // FileManagerHelper.WorkingDir = dir;
            }
        }

        public void StartBackup(string workDir)
        {
            int choice = GetBackupNumber();
            ClearDirectory(workDir);   // Чистим рабочую директорию.
            // Копируем в рабочую директорию нужный бэкап.
            fileManagerHelper.CreateDirectoryCopy(this._backups[choice], workDir);
        }

        // Метод выводит на экран пользователя список доступных бэкапов.
        private void ShowAvailableBackups()
        {
            if (this._backups.Length > 1)
            {
                for (int i = 0; i < this._backups.Length; i++)
                {
                    Console.WriteLine($"{i + 1}: {new DirectoryInfo(this._backups[i]).Name}");
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
