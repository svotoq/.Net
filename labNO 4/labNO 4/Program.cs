using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labNO_4
{
    class Program
    {
        static void Main(string[] args)
        {
            IntArray x = new IntArray(4);
            IntArray y = new IntArray(4);
            x[0] = 1; x[1] = 2; x[2] = 3; x[3] = 0;
            y[0] = 3; y[1] = -2; y[2] = -3; y[3] = 1;
            Console.WriteLine("Оператор Умножить: ");
            IntArray xy = y * x;
            for (int i = 0; i < xy.count; i++)
            {
                Console.WriteLine("{0} элемент: {1}", i, xy[i]);
            }
            if (y)
            {
                Console.WriteLine("\nНет отрицательных");
            }
            else
            {
                Console.WriteLine("\nЕсть отриательные числа");
            }
            Console.WriteLine("\nОперации сравнения");
            if (x < y)//==,!=,>,< 
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
            Console.WriteLine("\nInfo about y: ID: {0}, NAME: {1}, ORGANISATION: {2}", y.Info.id, y.Info.name, y.Info.org);
            IntArray.Date wtf = new IntArray.Date();
            Console.WriteLine("Create Time: {0}", wtf.GetDate);
            Console.WriteLine("\nMax in x: " + MathOperation.Max(x));
            Console.WriteLine("Min in y: " + MathOperation.Min(y));
            Console.WriteLine("Count of elem in y: " + MathOperation.Size(y));
            Console.WriteLine("\n");
            string str = "hello world";
            Console.WriteLine(str);
            Console.Write("Присутствует ли символ \"w\" в строке: {0}\n", MathOperation.CheckSymbol(str, "w"));
            Console.WriteLine("\nУдаление отрицательный элементов в массиве y");
            y = MathOperation.Delete(y);
            Console.WriteLine("Новый размер массива y: " + y.count);
        }
    }
}

