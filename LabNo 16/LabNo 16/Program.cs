using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace LabNo16
{

    class Program
    {

        static void Main(string[] args)
        {
            //задание 1 матрицы
            Stopwatch stopwatch = new Stopwatch();
            int[,] matA = { { 2, 2, 2 },
                            { 2, 2, 2 },
                            { 2, 2, 2 } };
            int[,] matB ={ { 3, 0, 0 },
                            { 0, 3, 0 },
                            { 0, 0, 3 }};
            int[,] res = new int[3, 3];
            Task task = new Task(() =>
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)

                    {
                        res[i, j] = 0;
                        for (int o = 0; o < 3; o++)
                        {
                            res[i, j] += matA[i, o] * matB[o, j];
                        }
                    }
                }
            });

            stopwatch.Start();
            task.Start();
            stopwatch.Stop();
            TimeSpan ts = stopwatch.Elapsed;
            ShowMatrix(res);
            Console.WriteLine("Время выполнения " + ts);
            Console.ReadKey();
            Console.Clear();

            //Задание 2 токен отмены
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;

            Task task1 = new Task(() =>
            {
                for (int i = 0; i <= 100; i++)
                {
                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine("Операция прервана");
                        return;
                    }
                    Console.Write(i + " .. ");
                    Thread.Sleep(250);
                }
            });
            task1.Start();
            Console.WriteLine("Введите Y или y:");
            string s = Console.ReadLine();
            if (s == "Y" || s == "y")
                cancelTokenSource.Cancel();
            Console.ReadKey();
            Console.Clear();
            //Задание 3
            int k = 0;
            Func<int> func = () =>
            {
                return k + 2;
            };

            Task<int> one = new Task<int>(func);
            Task<int> two = new Task<int>(func);
            Task<int> three = new Task<int>(func);

            one.Start();
            two.Start();
            three.Start();
            Console.WriteLine($"1){one.Result}\n2){two.Result}\n3){three.Result}");
            Func<int> function = () =>
            {
                return one.Result + two.Result + three.Result;
            };

            Task<int> resultat = new Task<int>(function);

            resultat.Start();

            Console.WriteLine("Результат = " + resultat.Result);
            Console.ReadKey();
            Console.Clear();

            //Задание 4
            Task firsttask = new Task(() =>
            {
                Console.WriteLine("Первая задача");
            });
            //continue-with

            Task taskContTwo = firsttask.ContinueWith(Display);
            firsttask.Start();
            taskContTwo.Wait();
            Console.WriteLine("main");
            Console.ReadKey();
            Console.Clear();
            //4.2
            Random rand = new Random();
            Task<int> what = Task.Run(() => 5 + 5);
            var awaiter = what.GetAwaiter();
            awaiter.OnCompleted(() =>
            {
                Console.WriteLine("Результат: " + awaiter.GetResult());
            });
            Console.ReadKey();
            Console.Clear();

            stopwatch.Restart();
            //Задание 5
            Parallel.For(1, 6, CreateBigArrFor);
            stopwatch.Stop();
            Console.WriteLine("Время при Parallel.For:  " + stopwatch.Elapsed + '\n');

            stopwatch.Restart();
            for (int j = 1; j < 6; j++)
            {
                int[] arr = new int[1000000];
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = rand.Next(10);
                }
            }
            stopwatch.Stop();
            Console.WriteLine("Время при For: " + stopwatch.Elapsed + '\n');
            Console.WriteLine();

            List<int> list = new List<int>() { 1, 2, 3, 4, 5 };

            stopwatch.Restart();
            ParallelLoopResult result = Parallel.ForEach<int>(list, CreateBigArrForeach);
            stopwatch.Stop();
            Console.WriteLine("Время при Parallel.Foreach: " + stopwatch.Elapsed + '\n');

            stopwatch.Restart();
            foreach (int x in list)
            {
                int[] arr = new int[1000000];
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = rand.Next(10);
                }
            }
            stopwatch.Stop();
            Console.WriteLine("Время при Foreach: " + stopwatch.Elapsed + '\n');
            Console.ReadKey();
            Console.Clear();
            //Задача 6
            Console.WriteLine("Parallel.Invoke");
            Parallel.Invoke(() => CreateBigArrFor(1), () => Display(task), () => GetFactorial(5));
            Console.ReadKey();
            Console.Clear();
            //7
            BlockingCollection<string> bc = new BlockingCollection<string>(20);
            Provider p1 = new Provider("бумага", 100);
            Provider p2 = new Provider("телефон", 200);
            Provider p3 = new Provider("комп", 300);
            Provider p4 = new Provider("майонез", 400);
            Provider p5 = new Provider("повербанк", 500);
            Customer c1 = new Customer(); Customer c2 = new Customer();
            Task bcTask = Task.Run(async () =>
            {
                while (bc.Count != bc.BoundedCapacity)
                {
                    Parallel.Invoke(
                        () => p1.AddToStore(bc),
                        () => p2.AddToStore(bc),
                        () => p3.AddToStore(bc),
                        () => p4.AddToStore(bc),
                        () => p5.AddToStore(bc),
                        () => c1.TakeFromStore(bc),
                        () => c2.TakeFromStore(bc)
                        );
                }
                Console.WriteLine("Склад полон");

            });
            Console.Write("\n\n");
            Console.ReadLine();
            Console.Clear();

            //задание
            FactorialAsync();
            Console.ReadKey();
            Console.Clear();
        }
        static void GetFactorial(int x)
        {
            int result = 1;

            for (int i = 1; i <= x; i++)
            {
                result *= i;
            }
            Console.WriteLine("Результат {0}", result);
        }
        static public void CreateBigArrForeach(int x)
        {
            Random rand = new Random();
            int[] arr = new int[1000000];
            foreach (int i in arr)
            {
                arr[i] = rand.Next(10);
            }
        }
        static public void CreateBigArrFor(int x)
        {
            Random rand = new Random();
            int[] arr = new int[1000000];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(10);
            }
        }
        static void Display(Task t)
        {
            Console.WriteLine("Еще задача");
        }
        static public void ShowMatrix(int[,] matr)
        {
            Console.WriteLine("Полученная матрица:\n");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write("\t" + matr[i, j]);
                }
                Console.WriteLine();
            }
        }

        static public int[,] Multiplay(int[,] matA, int[,] matB)
        {
            int[,] res = new int[5, 5];

            return res;
        }
        class Customer
        {
            public void TakeFromStore(BlockingCollection<string> bc)
            {
                Random rand = new Random();
                if (bc.Count == 0)
                {
                    Console.WriteLine("На складе пусто");
                    Thread.Sleep(rand.Next(1000));
                }
                else
                {
                    bc.Take();
                    Console.WriteLine("Купили");
                    Thread.Sleep(rand.Next(1000));
                }
            }
        }
        public static void method()
        {
            for (int i = 0; i < 1000; i++)
            {
                if (i == 100)
                    Console.WriteLine();
                Console.Write(i + " - ");
                Thread.Sleep(250);
            }
        }
        class Provider
        {
            public string thing;
            public int timing;
            public Provider(string s, int i)
            {
                thing = s;
                timing = i;
            }
            public async Task AddToStore(BlockingCollection<string> bc)
            {
                await Task.Run(() =>
                {
                    bc.Add(this.thing);
                    Console.WriteLine("Завезли " + thing);
                    Thread.Sleep(timing);
                });

            }
        }
        static async void FactorialAsync()
        {
            Console.WriteLine("Запустили");
            await Task.Run(() => GetFactorial(3));
            Console.WriteLine("Закончили");
        }
    }
}