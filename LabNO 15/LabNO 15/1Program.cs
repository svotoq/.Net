using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;
namespace LabNO_15
{
    class Program
    {
        static public int n;
        static void Main(string[] args)
        {
            using (StreamWriter sw = new StreamWriter(@"E:\Учеба\БГТУ\2 курс\1 семестр\ООП\Labs\LabNO 15\ProcessesInfo.txt"))
            {
                foreach (Process process in Process.GetProcesses())
                {
                    sw.WriteLine("ID: {0}  Name: {1}  Priority: {2}", process.Id, process.ProcessName, process.BasePriority);
                }
                Console.WriteLine("Информация о процессах записанпа в файл ProcessInfo.txt");
            }

            Console.WriteLine("\n\nИнформация о текущем домене и сборках");
            AppDomain Dom = AppDomain.CurrentDomain;
            Console.WriteLine("Name: {0}", Dom.FriendlyName);
            Console.WriteLine("Base Directory: {0}", Dom.BaseDirectory);
            Console.WriteLine();

            Assembly[] assemblies = Dom.GetAssemblies();
            foreach (Assembly asm in assemblies)
                Console.WriteLine(asm.GetName().Name);

            Console.WriteLine("\nМой домен");
            AppDomain MyDom = AppDomain.CreateDomain("MyDomain");
            // событие загрузки сборки
            MyDom.AssemblyLoad += MyDom_AssemblyLoad;
            // событие выгрузки домена
            MyDom.DomainUnload += MyDom_DomainUnload;

            Console.WriteLine("Домен: {0}", MyDom.FriendlyName);
            //MyDom.Load(new AssemblyName("System.Linq")); 
            Assembly[] assembl = MyDom.GetAssemblies();
            foreach (Assembly asm in assembl)
                Console.WriteLine(asm.GetName().Name);
            // выгрузка домена
            AppDomain.Unload(MyDom);

            Thread thread = new Thread(simpleNumbers);
            thread.Name = "Writer";
            Console.WriteLine("Введите n");
            n = int.Parse(Console.ReadLine());
            thread.Start();

                Console.WriteLine($"\n\n\nName of thread: {thread.Name}");
                Console.WriteLine($"Priority of thread: {thread.Priority}");
                Console.WriteLine($"State of thread: {thread.ThreadState}");
                Console.WriteLine($"State of thread: {thread.ManagedThreadId}");
            Thread.Sleep(100);
            Thread first = new Thread(even);
            first.Priority = ThreadPriority.Highest;
            first.Start();
            Thread second = new Thread(odd);
            Console.Read();
        }
        private static void MyDom_DomainUnload(object sender, EventArgs e)
        {
            Console.WriteLine("Домен выгружен из процесса");
        }

        private static void MyDom_AssemblyLoad(object sender, AssemblyLoadEventArgs args)
        {
            Console.WriteLine("Сборка загружена");
        }

        static Mutex mutexObj = new Mutex();
        static object locker = new object();
        public static void simpleNumbers()
        {
            using (StreamWriter fs = new StreamWriter(@"E:\Учеба\БГТУ\2 курс\1 семестр\ООП\Labs\LabNO 15\simpleNumbers.txt"))
            {
                for (int i = 0; i <= n; i++)
                {
                    Console.WriteLine(i);
                    fs.WriteLine(i);
                    if(i==5)
                        Thread.Sleep(100);
                }
            }
        }
        public static void even()
        {
            for (int i = 0; i < n; i += 2)
            {
                using (StreamWriter fs = new StreamWriter(@"E:\Учеба\БГТУ\2 курс\1 семестр\ООП\Labs\LabNO 15\nums.txt"))
                {
                    Console.WriteLine("Чет:" + i);
                    fs.WriteLine(i);
                }
            }
        }
        public static void odd()
        {
            for (int i = 1; i < n; i += 2)
            {
                using (StreamWriter fs = new StreamWriter(@"E:\Учеба\БГТУ\2 курс\1 семестр\ООП\Labs\LabNO 15\nums.txt"))
                {
                    Console.WriteLine("Нечет: " + i);
                    fs.WriteLine(i);
                }
            }
        }
    }
}
