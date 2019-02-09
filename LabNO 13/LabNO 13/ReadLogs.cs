using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace LabNO_13
{
    class ReadLogs
    {
        public static void ReadFromLogFile()
        {
            using (StreamReader streamReader = new StreamReader(@"E:\Учеба\БГТУ\2 курс\1 семестр\ООП\Labs\LabNO 13\Logs.txt"))
            {
                Console.WriteLine();
                string str = streamReader.ReadToEnd();
                Console.WriteLine(str);

            }
        }
    }
}
