using System;
using System.Linq;

namespace labNo_5
{
    //моя иерархия исключений
    class ZeroInString
    {
        public string Str { get; set; }
        public void CheckZeroInString()
        {
            Console.WriteLine("Введите строку с 0: ");
            this.Str = Console.ReadLine();
            if (Str.Contains('0'))
            {
                Console.WriteLine("Строка содержит 0");
            }
            else
            {
                Console.WriteLine("ERROR!! Строка не содержит 0");
            }
        }
    }
    class ArrayException : ZeroInString
    {
        int[] array = new int[5] { 12, 2, 31, 4, 0 };
        public void MethodArrayException()
        {
            Console.WriteLine("\nЭлементы массива:");
            foreach (int i in array)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("\nКакой элемент массива хотите вывести?(oт 0 до 4)");
            int x = Convert.ToInt32(Console.ReadLine());

            if (x > array.Length)
            {
                Console.WriteLine("\nОшибка.Элементов в массиве меньше введенного числа");
            }
            else
            {
                Console.WriteLine("\nВывод заданного по номеру элемента массива:");
                Console.WriteLine(array[x]);
            }
        }
    }
    class ZeroDivisonException : ArrayException
    {
        public void MethodZeroDivisonException()
        {
            Console.Write("x = ");
            double x = Convert.ToDouble(Console.ReadLine());
            Console.Write("y = ");
            double y = Convert.ToDouble(Console.ReadLine());
            if (y == 0)
            {
                Console.WriteLine("ERROR!! Деление на 0");
            }
            else
            {
                Console.WriteLine("Результат деления = " + x / y);
            }
        }
    }
    //Сделать наследование пользовательских типов исключений от стандартных классов.Net(например Exception)
    class SpaceException : Exception
    {
        public SpaceException(string message) : base(message)
        {
        }
    }
    class MyName
    {
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value == " ")
                {
                    throw new SpaceException("\nПробел вместо имени.");
                }
                else
                {
                    name = value;
                }
            }
        }
    }

    public class MyException : ApplicationException
    {
        public MyException() { }
        public MyException(string message) : base(message) { }
        public MyException(string message, Exception ex) : base(message) { }
    }

    public class Divison
    {
        public int MyDivison(int x, int y)
        {
            if (y == 0)
            {
                MyException exc = new MyException("ОШИБКА: деление на 0");
                exc.HelpLink = "http:\\mitanit.com";
                throw exc;
            }
            return x / y;
        }
    }
}
