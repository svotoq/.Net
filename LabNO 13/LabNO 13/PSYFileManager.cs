using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
namespace LabNO_13
{
    class PSYFileManager
    {
        public static void WithFiles()
        {
            {
                Console.WriteLine("\nДиректорий создан.");
                Directory.CreateDirectory("E:\\Учеба\\БГТУ\\2 курс\\1 семестр\\ООП\\Labs\\LabNO 13\\PSYInspect");
                Console.WriteLine("Создание файла и запись в него.");

                using (StreamWriter streamWriter = new StreamWriter("E:\\Учеба\\БГТУ\\2 курс\\1 семестр\\ООП\\Labs\\LabNO 13\\PSYInspect\\PSYdirinfo.txt"))
                {
                    streamWriter.Write("Something");
                    streamWriter.Close();
                }

                Console.WriteLine("\nСоздана копия файла.");
                File.Copy("E:\\Учеба\\БГТУ\\2 курс\\1 семестр\\ООП\\Labs\\LabNO 13\\PSYInspect\\PSYdirinfo.txt", "E:\\Учеба\\БГТУ\\2 курс\\1 семестр\\ООП\\Labs\\LabNO 13\\PSYInspect\\CopyPSYdirinfo.txt");

                Console.WriteLine("Первый файл удален.");
                File.Delete("E:\\Учеба\\БГТУ\\2 курс\\1 семестр\\ООП\\Labs\\LabNO 13\\PSYInspect\\PSYdirinfo.txt");

                Directory.CreateDirectory("E:\\Учеба\\БГТУ\\2 курс\\1 семестр\\ООП\\Labs\\LabNO 13\\PSYFiles");
                File.Copy("E:\\Учеба\\БГТУ\\2 курс\\1 семестр\\ООП\\Labs\\LabNO 13\\PSYInspect\\CopyPSYdirinfo.txt", "E:\\Учеба\\БГТУ\\2 курс\\1 семестр\\ООП\\Labs\\LabNO 13\\PSYFiles\\NewCopyPSYdirinfo.txt");
            }
        }
        public static void WithDir()
        {
            string[] listFiles = Directory.GetFiles("E:\\Учеба");
            string[] listDirectories = Directory.GetDirectories("E:\\Учеба");
            Console.WriteLine("\nФайлы каталога E:\\Учеба");
            foreach (string i in listFiles)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("\nПапки каталога E:\\Учеба");
            foreach (string j in listDirectories)
            {
                Console.WriteLine(j);
            }
        }
        public static void Zip()
        {
            string startPath = "E:\\Учеба\\БГТУ\\2 курс\\1 семестр\\ООП\\Labs\\LabNO 13\\PSYFiles";
            string zipPath = "E:\\Учеба\\БГТУ\\2 курс\\1 семестр\\ООП\\Labs\\LabNO 13\\result.zip";
            string extractPath = "E:\\Учеба\\БГТУ\\2 курс\\1 семестр\\ООП\\Labs\\LabNO 13\\exctract";
            ZipFile.CreateFromDirectory(startPath, zipPath);
            Console.WriteLine("Заархивировано! путь: " + zipPath);
            ZipFile.ExtractToDirectory(zipPath, extractPath);
            Console.WriteLine("Разархивировано! путь: " + extractPath);
        }
    }
}
