using System;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Types();
            //Strings();
            //Arrays();
            //Cortege();
            int[] ArrayInt32 = { 3, 4, 5, 2, 4, 2, 4 };
            string str = "HELLOW";
            str = MyFunction(ArrayInt32, str, out int max, out int min);
            Console.WriteLine($"Макс: {max}\nМин: {min}\nПервый символ строки: {str} ");
        }

        static void Types()


        {
            //1 Типы
            bool boolPrimit = true;
            byte bytePrimit = 255;  // Хранит число в 1 байт
            sbyte sbytePrimit = -100; // byte со знаком
            short shortPrimit = 32767;
            ushort ushortPrimit = 65535;
            int intPrimit = 1000;
            uint uintPrimit = 13123;
            long longPrimit = 123132;
            ulong ulongPrimit = 1323;
            float floatPrimit = 123.456F;
            double doublePrimit = 123.456789;
            decimal decimalPrim = 3235456; //  хранит десятичное дробное число. Если употребляется без десятичной запятой, 
                                           //имеет значение от 0 до +/–79 228 162 514 264 337 593 543 950 335; если с запятой, то от 0 до +/–7,9228162514264337593543950335
                                           //с 28 разрядами после запятой и занимает 16 байт. Представлен системным типом System.Decimal
            char charPrimit = 'a';
            string stringPrimit = "aaaa"; // unicode 2byte
            object a = 22;
            object b = 3.14;
            object c = "hello code";
            // может хранить значение любого типа данных и занимает 4 байта на 32-разрядной платформе и 8 байт на 64-разрядной платформе. 
            //Представлен системным типом System.Object, который является базовым для всех других типов и классов .NET.

            //2 Приведения
            //1.Явные
            short ByteToShort = bytePrimit;
            int ShortToInt32 = ByteToShort;
            long IntToInt64 = ShortToInt32;
            decimal In64ToDecimal = IntToInt64;
            byte IntToByte = Convert.ToByte(ShortToInt32);
            //2.Неявные
            shortPrimit = sbytePrimit;
            intPrimit = shortPrimit;
            longPrimit = intPrimit;
            doublePrimit = floatPrimit;
            decimalPrim = intPrimit;

            //3. boxing
            //упаковка
            //распоковка

            //4. неявно тип. переменная
            var nT = 'h';
            var nT2 = "hi";
            var nT3 = 22;

            //5. Nullable переменная
            int? nullInt = null;
            if (!nullInt.HasValue)
            {
                nullInt = 225;
                Console.WriteLine($"nullInt: {nullInt}\n");
            }


        }

        static void Strings()
        {
            //1. Сравнение    
            string s4 = new String(new char[] { 'w', 'o', 'r', 'l', 'd' });
            string s5 = new String(new char[] { 'w', 'o', 'r', 'l', 'd' });
            if (Equals(s4, s5))
            {
                Console.WriteLine("Строки равны!");
            }
            else
            {
                Console.WriteLine("Строки не равны!");
            }

            //2. сцепление
            string s1 = "hello";
            string s2 = String.Concat(s1, "world");

            //копирование
            string s3 = String.Copy(s2);

            //выделение подстроки
            s2 = s2.Substring(2, 5);

            //разделение строки на слова
            s1 = "hello wolrd !!!";
            string[] string1 = s1.Split(' ');

            //вставки подстроки в заданную позицию
            s1 = s1.Insert(6, " world");
            //удаление заданной подстроки.
            s1 = s1.Remove(6, 5);

            //3. пустая и null строка
            string sr1 = "";
            string sr2 = null;
            if (sr1.Equals(sr2))
            {
                Console.WriteLine("Равны!");
            }
            else
            {
                Console.WriteLine("Не равны!");

            }

            //4. StringBuilder
            StringBuilder stringBuilder = new StringBuilder("hello");
            //удалить
            stringBuilder.Remove(3, 5);
            //добавить в начало
            stringBuilder.Append(" end of string");
            //добавить в конец
            stringBuilder.Insert(0, "beging");



        }

        static void Arrays()
        {
            //1 Целый двумерный массив
            int[,] ArrInt32 = new int[,]
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };

            int rows = ArrInt32.GetUpperBound(0) + 1;
            int columns = ArrInt32.Length / rows;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(ArrInt32[i, j] + " ");
                }
                Console.WriteLine();
            }

            //2. массив строк
            string[] str =
            {
                "hello wrold",
                "BSTU ONE LOVE",
                "hello world 123"
            };
            foreach (string i in str)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("Длинна массива = " + str.Length);

            Console.Write("\nВведите номер элемента: ");
            int Position = Convert.ToInt32(Console.ReadLine());
            Console.Write("Новая строка: ");
            str[Position] = Convert.ToString(Console.ReadLine());
            Console.WriteLine($"Строка номер {Position} = {str[Position]}");

            //ступечатый (не выровненный) 
            float[][] ArrayFloat = new float[3][];
            ArrayFloat[0] = new float[2];
            ArrayFloat[1] = new float[3];
            ArrayFloat[2] = new float[4];
            Console.WriteLine("Ввод float массива:");

            for (int i = 0; i < ArrayFloat.Length; i++)
            {
                for (int j = 0; j < ArrayFloat[i].Length; j++)
                {
                    ArrayFloat[i][j] = Convert.ToSingle(Console.ReadLine());
                }
            }

            foreach (float[] row in ArrayFloat)
            {
                foreach (float number in row)
                {
                    Console.Write($"{number} \t");
                }
                Console.WriteLine();
            }

            //4. Неявно типизированные переменные 
            var VarArr = new[] { 12, 16, 14 };
            var VarStr = "Неявнотипизированная строка";
        }

        static void Cortege()
        {
            //1 кортеж на 5 эл для опред. типов 
            (int, string, char, string, ulong) cortage = (1, "string1", 'c', "string2", 2555);
            
            //именование элементов
            var cortage2 = (int32: 2, str1: "string3", symbol: 's', str2: "string4", Ulong: 2352532);
            
            //вывод кортежа
            Console.WriteLine("Кортеж 1: " + cortage);
            Console.WriteLine($"Кортеж 2: {cortage2.Item1}, {cortage2.Item3}, {cortage2.Item4}");
            
            //Распаковка кортежа
            string str = cortage2.str1;

            //сравнение кортежа
            bool Result = cortage.Equals(cortage2);
            Console.WriteLine("Равенство кортежей: " + Result);
        }

        static string MyFunction(int[] numbers, string str, out int max, out int min)
        {
            min = numbers[0]; int minIndex = 0;
            for (int i = 0; i < numbers.Length-1; i++)
            {
                if (min > numbers[i])
                {
                    min = numbers[i];
                    minIndex = i;
                }
            }

            max = numbers[0]; int maxIndex = 0;
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (max < numbers[i])
                {
                    max = numbers[i];
                    maxIndex = i;
                }
            }
            return str = str.Substring(0, 1);
        }
    }
}
