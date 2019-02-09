using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LabNO_13
{
    class PSYFileInfo
    {
        public static void Fileinfo()
        {
            FileInfo fileInfo = new FileInfo(@"E:\Учеба\БГТУ\2 курс\1 семестр\ООП\Labs\LabNO 13\Logs.txt");
            Console.WriteLine($"\n\nИмя файла: {fileInfo.Name}");
            Console.WriteLine($"Полный путь файла: {fileInfo.DirectoryName}");
            Console.WriteLine($"Размер файла: {fileInfo.Length}");
            Console.WriteLine($"Размер файла: {fileInfo.Length}");
            Console.WriteLine($"Расширение файла: {fileInfo.Extension}");
            Console.WriteLine($"Время создания файла: {fileInfo.CreationTime}");
        }
    }
}
