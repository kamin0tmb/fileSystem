using System;
using System.IO;
using System.Linq;
using DirectoryE;

namespace DriveManager
{
    
    class Program
    {
        public static FileInfo configFile = new FileInfo(@"C:\Users\kamin0\Desktop\SystemConfig.txt");
        static void Main(string[] args)
        {
            // получим системные диски
            DriveInfo[] drives = DriveInfo.GetDrives();

            // Пробежимся по дискам и выведем их свойства
            foreach (DriveInfo drive in drives.Where(d => d.DriveType == DriveType.Fixed))
            {
                

                DirectoryInfo root = drive.RootDirectory;
                var folders = root.GetDirectories();
                Console.WriteLine($"Сканируется диск {drive.Name}") ;
                using (StreamWriter sw = configFile.AppendText())
                {
                    WtiteDriveInfo(drive, sw);
                    WtiteFileInfo(root, sw);
                    WtiteFolderInfo(folders, sw);
                }
                Console.WriteLine("завершено");
                Console.WriteLine("___");
            }
        }

        public static void WtiteDriveInfo(DriveInfo drive, StreamWriter sw)
        {
            sw.WriteLine($"Название: {drive.Name}");
            sw.WriteLine($"Тип: {drive.DriveType}");
            if (drive.IsReady)
            {
                sw.WriteLine($"Объем: {drive.TotalSize}");
                sw.WriteLine($"Свободно: {drive.TotalFreeSpace}");
                sw.WriteLine($"Метка: {drive.VolumeLabel}");
            }
        }
        public static void WtiteFolderInfo(DirectoryInfo[] folders, StreamWriter sw)
        {
            sw.WriteLine();
            sw.WriteLine("Папки: ");
            sw.WriteLine();
            foreach (var folder in folders)
            {
                try
                {
                    sw.WriteLine(folder.Name + "- {0} байт", DirectoryExtension.DirSize(folder));
                }
                catch (Exception e)
                {
                    sw.WriteLine(folder.Name + " Не удалось рассчитать размер - ошибка: {0}", e.Message);
                }
            }
        }
        public static void WtiteFileInfo(DirectoryInfo rootFolder, StreamWriter sw)
        {
            sw.WriteLine();
            sw.WriteLine("Файлы: ");
            sw.WriteLine();
            foreach (var files in rootFolder.GetFiles())
            {
                
                    sw.WriteLine(files.Name + "- {0} байт", files.Length);
                
            }
        }

    }
}