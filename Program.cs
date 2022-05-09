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
            //CatalogMove();
            //CatalogDelete();
            Trash();

        }

        static void GetCatalogs()
        {
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(@"C:\Users\kamin0\Desktop\" /* Или С:\\ для Windows */ );
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
            DirectoryInfo dirInfo = new DirectoryInfo(@"C:\Users\kamin0\Desktop\");
            if (!dirInfo.Exists)
                dirInfo.Create();

            dirInfo.CreateSubdirectory("NewFolder");
        }

        //static void CatalogDelete()
        //{
        //   try
        //    {
         //       DirectoryInfo dirInfo = new DirectoryInfo(@"D:\\2\");
          //      dirInfo.Delete(true); // Удаление со всем содержимым
           //     Console.WriteLine("Каталог удален");
           // }
           // catch (Exception ex)
           // {
           //     Console.WriteLine(ex.Message);
           /// }
        //}
        static void CatalogMove()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(@"C:\Users\kamin0\Desktop\NewFolder");
            string newPath = @"C:\$RECYCLE.BIN\NewFolder";

            if (dirInfo.Exists && Directory.Exists(@"C:\Users\kamin0\Desktop\NewFolder")) ;
            dirInfo.MoveTo(newPath);

        }
        static void Trash()
        {
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(@"C:\Users\kamin0\Desktop\NewFolder");
                string trashPath = @"C:\$RECYCLE.BIN\NewFolder";

                dirInfo.MoveTo(trashPath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
