using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LabNO_13
{
    class PSYDirInfo
    {
        public static void DirInfo()
        {
            Console.WriteLine("\n\nПодкаталоги в папке Windows:");
            string[] dirs = Directory.GetDirectories("C:\\Windows");
            foreach (string s in dirs)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine($"\nКоличество подкаталогов в папке Windows = {dirs.Length}");
            Console.WriteLine("\nФайлы:");
            string[] files = Directory.GetFiles("C:\\Windows");
            foreach (string s in files)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine($"\nКоличество файлов в папке Windows ={files.Length}");
            var time = Directory.GetCreationTime("C:\\Windows");
            Console.WriteLine($"Дата создания папки Windows: {time}");
            var parent = Directory.GetParent("C:\\Windows");
            Console.WriteLine($"Родитель папки Windows: {parent}");
        }
    }
}
