using System;

namespace LabNo_9
{
    public delegate void AllMethods();
    class Program
    {
        static void Main(string[] args)
        {
            for (; ; )
            {
                Console.WriteLine("1. Задание 1");
                Console.WriteLine("2. Задание 2");
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1: Console.Clear(); Zad1(); Console.Clear(); break;
                    case 2: Console.Clear(); Zad2(); Console.Clear(); break;
                    default: Console.Clear(); break;
                }
            }
        }
        private static void Show_Message(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red; 
            Console.WriteLine(message);
            Console.ResetColor();
        }
        static void Zad1()
        {
            Console.WriteLine("\nЗАДАНИЕ 1\n");
            Boss Zver = new Boss("ЗВЕРЬ", "ROBOT");
            OneHit oneHit = new OneHit(Zver.Atack);
            ThreeHit threeHit = new ThreeHit(Zver.Atack);
            threeHit += Zver.Atack;
            threeHit += Zver.Atack;
            Zver.Attacked += Show_Message;
            Console.WriteLine("Двигаясь по лабиринту вы увидели странный силуэт...");
            Console.WriteLine("!!!!!СИСТЕМА!!!!!");
            Console.WriteLine("МОБ опознан, хотите вызвать справку? да/нет");
            if (Console.ReadLine() == "да")
            {
                Boss.Help(Zver);
            }
            Console.WriteLine("Желаете напасть? да/нет");
            if (Console.ReadLine() == "да")
            {
                oneHit();
                threeHit();
                oneHit();
                Console.WriteLine("Проверить состояние моба? да/нет");
                if (Console.ReadLine() == "да")
                {
                    Boss.Status(Zver);
                }
                Console.WriteLine("Добить моба? да/нет");
                if (Console.ReadLine() == "да")
                {
                    threeHit();
                }
            }
            Boss Petya = new Boss("Петя", "Petya");
            Console.WriteLine("В темноте вы увидели еще одно существо\n" +
                "Оно движется на вас!\n" +
                "Желаете напасть? да/нет");
            if (Console.ReadLine() == "да")
            {
                Petya.Atack();
                Console.WriteLine("Хотите вызвать справку? да/нет");
                if (Console.ReadLine() == "да")
                {
                    Boss.Help(Petya);
                }
            }
            Console.WriteLine("Конец игры! Где-то тут должны быть титры...");
            Console.ReadLine();
        }
        static void Zad2()
        {
            Console.WriteLine("\nЗАДАНИЕ 2\n");
            StringMethods test = new StringMethods
            {
                CurrentString = "Тестовая,   строка,   привет   ААББВВ."
            };
            Console.WriteLine(test.CurrentString);
            
            AllMethods allMethods = test.DeleteCommas;
            allMethods += test.RemoveSpaces;
            allMethods += test.ToUpperCase;
            allMethods();
            Console.WriteLine(test.CurrentString);
            Action<int, int> add;
            add = test.AddCharacters;
            CharacterPos(10, 5, add);
            Func<char, char, string> Replace = test.ReplaceAtoB;
            Console.WriteLine(Check(' ', '\\', Replace));
            Console.ReadLine();
        }
        static void CharacterPos(int max, int min, Action<int, int> add)
        {
            if (min > max)
            {
                add(max, min);
            }
            else
            {
                add(min, max);
            }
        }
        static string Check(char A, char B, Func<char, char, string> Replace)
        {
            
            return Replace(A, B);

        }
    }
}
