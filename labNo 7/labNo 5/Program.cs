using System;
using System.Diagnostics;

namespace labNo_5
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                ZeroInString zeroInString = new ZeroInString();
                zeroInString.CheckZeroInString();
                ArrayException arrayException = new ArrayException();
                arrayException.MethodArrayException();
                ZeroDivisonException zeroDivisonException = new ZeroDivisonException();
                zeroDivisonException.MethodZeroDivisonException(); //деление на 0
                MyName myName = new MyName();
                try
                {
                    Console.Write("Введите имя: ");
                    myName.Name = Console.ReadLine();
                }
                catch (SpaceException ex)
                {
                    Console.WriteLine("Ошибка: " + ex.Message);
                    Console.WriteLine("Метод: " + ex.TargetSite);
                    Console.WriteLine("Имя объекта или сборки, которое вызвало исключение: " + ex.Source);
                    Console.WriteLine("Cтроковое представление стека вызывов, которые привели к возникновению исключения: " + ex.StackTrace);
                }
                Value value = new Value();
                value.MethodValue();
                Divison divison = new Divison();
                try
                {
                    divison.MyDivison(6, 0);
                }
                catch (MyException ex)
                {
                    Console.WriteLine("\nВозникла ошибка, знаменатель равен нулю");
                    Console.WriteLine("Ошибка: " + ex.Message);
                    Console.WriteLine("Метод: " + ex.TargetSite);
                    Console.WriteLine("Имя объекта или сборки, которое вызвало исключение: " + ex.Source);
                    Console.WriteLine("Cтроковое представление стека вызывов, которые привели к возникновению исключения: " + ex.StackTrace);
                }
                finally
                {
                    Console.WriteLine("\nБлок finally");
                }
                //----------------------------------------работа с макросом Assert
                int[] arr = null;
                Debug.Assert(arr != null, "Массив не может быть равен null");
                string str = null;
                Debug.Assert(str != null, "строка не может быть пустой");
            }
        }
        class Value
        {
            public void MethodValue()
            {
                try
                {
                    Console.Write("Введите число: ");
                    int value = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Done!");
                }
                catch (Exception)
                {
                    Console.WriteLine("Введено не число!");
                }
            }
        }
    }
}