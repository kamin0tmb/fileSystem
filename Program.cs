using System;
using System.IO;


namespace fileSystem
{
    class Program
    {

        static void Main(string[] args)
        {
            CreateCatalog();
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
        static void CreateCatalog()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(@"D:\\2\");
            if (!dirInfo.Exists)
                dirInfo.Create();

            dirInfo.CreateSubdirectory("NewFolder");
            }
        }
        
    }

