using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileManagerClassLibrary
{
    internal class FileManagerHelper
    {
        internal string WorkingDir { get; set; }
        internal string BackupDir { get; set; }
        internal string Date { get => DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss"); }

        internal void CreateBackup(string work, string backup)
        {
            string backupDate = Date;

            // Создаём директории в бэкапе.
            foreach (var dir in Directory.GetDirectories(work, "*", SearchOption.AllDirectories))
            {
                try
                {
                    Directory.CreateDirectory(dir.Replace(work, backup + backupDate));
                }
                catch
                {
                    // Console.WriteLine(ex.Message);
                    // throw new Exception("Unexpected exception occured while copying directories!");
                }
                //finally
                //{
                //    Console.WriteLine("Copying dirs ended.");
                //}
            }

            Console.WriteLine("Copying dirs ended.");

            // Копируем файлы в бэкап.
            foreach (var file in Directory.GetFiles(work, "*.txt", SearchOption.AllDirectories))
            {
                try
                {
                    File.Copy(file, file.Replace(work, backup + backupDate), true);
                }
                catch
                {
                    // Console.WriteLine(ex.Message);
                    // throw new Exception("Unexpected exception occured while copying files!");
                }
                //finally
                //{
                //    Console.WriteLine("Copying txts ended.");
                //}
            }

            Console.WriteLine("Copying txts ended.");
        }

        internal void CreateDirectoryCopy(string copyFromPath, string copyToPath)
        {
            foreach (var dir in Directory.GetDirectories(copyFromPath, "*", SearchOption.AllDirectories))
            {
                try
                {
                    Directory.CreateDirectory(dir.Replace(copyFromPath, copyToPath));
                }
                catch
                {
                    // Console.WriteLine(ex.Message);
                    // throw new Exception("Unexpected exception occured while copying directories!");
                }
                //finally
                //{
                //    Console.WriteLine("Copying dirs ended.");
                //}
            }

            Console.WriteLine("Copying dirs ended.");

            foreach (var file in Directory.GetFiles(copyFromPath, "*.txt", SearchOption.AllDirectories))
            {
                try
                {
                    File.Copy(file, file.Replace(copyFromPath, copyToPath), true);
                }
                catch
                {
                    // Console.WriteLine(ex.Message);
                    // throw new Exception("Unexpected exception occured while copying files!");
                }
                //finally
                //{
                //    Console.WriteLine("Copying txts ended.");
                //}
            }

            Console.WriteLine("Copying txts ended.");
        }
    }
}
