using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace FileManagerClassLibrary
{
    public class FileManager : IFileManagable
    {
        public string WorkPath { get; private set; }

        public FileManager(string path)
        {
            WorkPath = path;
        }

        // Метод, запускающий файловый менеджер.
        public void Run()
        {
            FileObserver fileObserver = new FileObserver(WorkPath);
            Thread observing = new Thread(fileObserver.StartObservation);

            int choice;

            Console.WriteLine("Input action:" + Environment.NewLine +
                  "1. Observation" + Environment.NewLine +
                  "2. Stop Observation" + Environment.NewLine +
                  "3. Backup" + Environment.NewLine +
                  "4. Exit" + Environment.NewLine +
                  "Input action number: " + Environment.NewLine);

            do
            {
                string inputNum = Console.ReadLine();
                int.TryParse(inputNum, out choice);
                switch (choice)
                {
                    case 1:
                        observing.Start();
                        break;
                    case 2:
                        observing.Abort();
                        break;
                    case 3:
                        FileBackupper fileBackupper = new FileBackupper(WorkPath);
                        fileBackupper.StartBackup();
                        break;
                    case 4:
                        return;
                }
            } while (choice > 0 && choice < 5);
        }
    }
}
