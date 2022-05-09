using System;
using System.IO;

namespace fileSystem
{
    class Program
    {

        static void Main(string[] args)
        {
            GetCatalogs(); //   Вызов метода получения директорий
        }

        static void GetCatalogs()
        {
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(@"D:\\" /* Или С:\\ для Windows */ );
                if (dirInfo.Exists)
                {
                    Console.WriteLine(dirInfo.GetDirectories().Length + dirInfo.GetFiles().Length);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }
    }
}
