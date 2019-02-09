using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabNO_13
{
    class Program
    {
        static void Main(string[] args)
        {
            PSYLog.WriteLogs();
            PSYDiskInfo.TotalFreeSpace();
            PSYDiskInfo.FileSystem();
            PSYDiskInfo.DiskInfo();
            PSYFileInfo.Fileinfo();
            PSYDirInfo.DirInfo();
            PSYFileManager.WithFiles();
            PSYFileManager.WithDir();
            PSYFileManager.Zip();
            ReadLogs.ReadFromLogFile();
        }
    }
}
