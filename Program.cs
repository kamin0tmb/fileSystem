using System;
using System.IO;
using System.Linq;
namespace DriveManager
{
    class Program
    {
        static void Main(string[] args)
        {
            // получим системные диски
            DriveInfo[] drives = DriveInfo.GetDrives();

            // Пробежимся по дискам и выведем их свойства
            foreach (DriveInfo drive in drives.Where(d => d.DriveType == DriveType.Fixed))
            {
                WtiteDriveInfo(drive);
                
                DirectoryInfo root = drive.RootDirectory;
                var folders = root.GetDirectories();
                WtiteFolderInfo(folders);
            }
        }

        public static void WtiteDriveInfo(DriveInfo drive)
        {
            Console.WriteLine($"Название: {drive.Name}");
            Console.WriteLine($"Тип: {drive.DriveType}");
            if (drive.IsReady)
            {
                Console.WriteLine($"Объем: {drive.TotalSize}");
                Console.WriteLine($"Свободно: {drive.TotalFreeSpace}");
                Console.WriteLine($"Метка: {drive.VolumeLabel}");
            }
        }
        public static void WtiteFolderInfo(DirectoryInfo [] folders)
        {
            Console.WriteLine();
            Console.WriteLine("Папки: ");
            Console.WriteLine();
            foreach (var folder in folders)
            {
                Console.WriteLine(folder.Name);
            }
        }

    }
}