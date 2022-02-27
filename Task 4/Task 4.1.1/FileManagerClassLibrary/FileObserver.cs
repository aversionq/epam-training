using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Serilog;

namespace FileManagerClassLibrary
{
    internal class FileObserver : IObservable
    {
        private FileSystemWatcher watcher;  // Объект для отслеживания состояния файлов.

        public FileObserver(string dir)
        {
            if (!Directory.Exists(dir))
            {
                throw new DirectoryNotFoundException("Directory not found!");
            }
            else
            {
                FileManagerHelper.WorkingDir = dir;

                // Конфигурация отслеживателя состояния файлов.
                watcher = new FileSystemWatcher(dir);
                watcher.Filter = "*.txt";
                watcher.NotifyFilter = NotifyFilters.Attributes
                                | NotifyFilters.DirectoryName
                                | NotifyFilters.FileName
                                | NotifyFilters.LastAccess
                                | NotifyFilters.LastWrite
                                | NotifyFilters.Size;

                // Создание директории с бэкапами.
                DirectoryInfo tempDirInfo = new DirectoryInfo(dir);
                FileManagerHelper.BackupDir = tempDirInfo.Parent + $@"\{tempDirInfo.Name}Backup\";
                _ = Directory.CreateDirectory(FileManagerHelper.BackupDir);
            }
        }

        public void StartObservation()
        {
            Console.WriteLine($"Started observing directory: {FileManagerHelper.WorkingDir}");

            watcher.EnableRaisingEvents = true;
            watcher.IncludeSubdirectories = true;

            watcher.Changed += this.OnChanged;
            watcher.Renamed += this.OnRenamed;
            watcher.Deleted += this.OnDeleted;
            watcher.Created += this.OnCreated;
        }

        // Случаи изменения файлов, на которые реагирует отслеживатель файлов.
        private async void OnChanged(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType != WatcherChangeTypes.Changed)
            {
                return;
            }
            Console.WriteLine($"Changed: {e.FullPath}");

            await Task.Run(() => FileManagerHelper.CreateBackup()); // Произошло изменение - создаём бэкап.
        }

        private async void OnCreated(object sender, FileSystemEventArgs e)
        {
            string value = $"Created: {e.FullPath}";
            Console.WriteLine(value);

            await Task.Run(() => FileManagerHelper.CreateBackup()); // Произошло изменение - создаём бэкап.
        }

        private async void OnDeleted(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"Deleted: {e.FullPath}");

            await Task.Run(() => FileManagerHelper.CreateBackup());  // Произошло изменение - создаём бэкап.
        }

        private async void OnRenamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine($"Renamed:");
            Console.WriteLine($"    Old: {e.OldFullPath}");
            Console.WriteLine($"    New: {e.FullPath}");

            await Task.Run(() => FileManagerHelper.CreateBackup());  // Произошло изменение - создаём бэкап.
        }
    }
}
