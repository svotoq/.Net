using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using System.IO;
using System.Threading;


namespace Lab15_thread
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                /*Определите и выведите на консоль/в файл все запущенные процессы:id, имя, приоритет,
                время запуска, текущее состояние, сколько всего времени использовал процессор и т.д.*/
                Console.WriteLine("Задание 1");
                var allProcesses = Process.GetProcesses();
                foreach (var proc in allProcesses)
                {
                    try
                    {
                        Console.WriteLine($"id:{proc.Id}; name: {proc.ProcessName}; start time: {proc.StartTime}; priority: {proc.PriorityClass}");
                    }
                    catch (Exception e)
                    {
                        //Console.WriteLine(e.Message); //Отказано в доступе
                    }
                }

                Console.WriteLine("\n\n");
                /*Исследуйте текущий домен вашего приложения: имя, детали конфигурации, все сборки,
                загруженные в домен. Создайте новый домен. Загрузите туда сборку. Выгрузите домен.*/
                Console.ReadKey();
                Console.WriteLine("Задание 2");
                AppDomain cur = AppDomain.CurrentDomain;            // домен и инфа
                Console.WriteLine($" name: {cur.FriendlyName} ");
                Console.WriteLine($" directory base: {cur.BaseDirectory} ");
                Console.WriteLine($" id: {cur.Id}");

                Console.WriteLine("\nassemblies:\n");

                Assembly[] asss = cur.GetAssemblies();
                foreach (Assembly assembly in asss)
                {
                    Console.WriteLine(assembly.GetName().Name);
                }
                // создание нового домена
                AppDomain anydomain = AppDomain.CreateDomain("anydomain");

                Console.WriteLine(anydomain.FriendlyName);
                AppDomain.Unload(anydomain);




                //  Создайте в отдельном потоке следующую задачу расчета(можно сделать sleep для
                //задержки) и записи в файл и на консоль простых чисел от 1 до n(задает пользователь).
                //Вызовите методы управления потоком(запуск, приостановка, возобновление и тд.) Во
                //время выполнения выведите информацию о статусе потока, имени, приоритете,
                //числовой идентификатор и т.д.
                //Console.ReadKey();
                //Console.WriteLine("Задание 3/4/5");
                //Thread myThread = new Thread(new ThreadStart(Sol1));
                //myThread.Name = "MyThread1";
                //Thread mainthr = Thread.CurrentThread;

                //myThread.Start();

                //for (int i = 0; i < 10; i++)
                //{
                //    if (myThread.IsAlive)
                //    {
                //        Console.WriteLine($"{i} Приор осн. {mainthr.Priority}'Основной поток'INFO({myThread.Name}): Работает:{myThread.ThreadState}, Приоритет:{myThread.Priority}, ");
                //        if (i == 3)

                //        {
                //            myThread.Suspend();
                //        }
                //        Thread.Sleep(300);
                //        if (i == 6)
                //        {
                //            myThread.Resume();
                //        }
                //    }
                //    else
                //    {
                //        Console.WriteLine($"{i} Приор осн. {mainthr.Priority}'Основной поток'; {myThread.Name} - завершен");
                //    }
                //    Thread.Sleep(300);

                //    //}



                int n = 10;
                Thread EvenNumb = new Thread(new ParameterizedThreadStart(PrintEvenNumber));
                Thread UnEvenNumb = new Thread(new ParameterizedThreadStart(PrintUnEvenNumber));

                //EvenNumb.Priority = ThreadPriority.Highest;           // изменение приоритета

                EvenNumb.Start(n);
                UnEvenNumb.Start(n);

                //TimerCallback meth = new TimerCallback(PrintInt);
                //Timer timer = new Timer(meth, 0, 0, 2500);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }

        static object locker = new object();

        public static void Sol1()
        {
            int n = 10;
            int.TryParse(Console.ReadLine(), out n);
            bool flag = true;
            for (int i = 1; i < n; i++)
            {
                for (int j = i; j > 1; j--)
                {
                    if (i % j == 0 && i != j && j != 1)
                    {
                        flag = false;
                    }
                }
                if (flag)
                {
                    Console.WriteLine($"{i}  'Второй поток'");
                    using (StreamWriter sw = new StreamWriter("Output.txt", true))
                    {
                        sw.WriteLine(i);
                    }
                }
                flag = true;
                Thread.Sleep(400);
            }
        }


        public static void PrintEvenNumber(Object parm)
        {
            // критическая секция
            int n = (int)parm;
            for (int i = 0; i < n; i++)
            {
                if (i % 2 == 0)
                    Console.WriteLine(i);       // попытка доступа к разделяемому ресурсу(консоль)
                Thread.Sleep(350);
            }
        }

        public static void PrintUnEvenNumber(Object parm)
        {
            int n = (int)parm;
            for (int i = 0; i <= n; i++)
            {
                if (i % 2 != 0)
                    Console.WriteLine(i);
                Thread.Sleep(350);
            }
        }

        public static void PrintInt(Object argument)
        {
            Random rnd = new Random();
            Console.WriteLine("random " + rnd.Next());
        }
    }
}
