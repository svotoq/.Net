using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LabNO_13
{
    class PSYLog
    {
        public static void WriteLogs()
        {
            try
            {
                FileInfo logs = new FileInfo(@"E:\Учеба\БГТУ\2 курс\1 семестр\ООП\Labs\LabNO 13\Logs.txt");
                var nameOfFile = logs.Name;
                var fullNameOfFile = logs.FullName;
                var timeOfCreate = logs.CreationTime;
                var timeOfAccess = logs.LastAccessTime;
                using (StreamWriter sm = new StreamWriter(@"E:\Учеба\БГТУ\2 курс\1 семестр\ООП\Labs\LabNO 13\Logs.txt", true))
                {
                    sm.WriteLine($"Имя файла: {nameOfFile}");
                    sm.WriteLine($"Полный путь к файлу: {fullNameOfFile}");
                    sm.WriteLine($"Дата и время создания файла пользователем: {timeOfCreate}");
                    sm.WriteLine($"Дата и время последнего изменения файла пользователем: {timeOfAccess}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
