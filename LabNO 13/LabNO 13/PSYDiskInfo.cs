using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LabNO_13
{
    class PSYDiskInfo
    {
        private static DriveInfo[] drivers = DriveInfo.GetDrives();

        public static void TotalFreeSpace()
        {
            foreach(DriveInfo di in drivers)
            {
                if (!di.IsReady) continue;
                Console.WriteLine($"Свободное место на диске {di.Name}: {di.TotalFreeSpace} bytes");
            }
            Console.WriteLine();
        }
        public static void FileSystem()
        {
            foreach (DriveInfo di in drivers)
            {
                if (!di.IsReady) continue;
                Console.WriteLine($"Файловая система на диске {di.Name}: {di.DriveFormat}");
            }
            Console.WriteLine();
        }
        public static void DiskInfo()
        {
            foreach (DriveInfo di in drivers)
            {
                if (!di.IsReady) continue;
                Console.WriteLine($"Имя: {di.Name}, объем: {di.TotalSize} bytes\n" +
                    $"Доступный объем: {di.AvailableFreeSpace}, метка тома: {di.RootDirectory}");
            }
            Console.WriteLine();
        }

    }
}
