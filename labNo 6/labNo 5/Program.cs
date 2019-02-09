using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace labNo_5
{
    struct Library
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }

        public void DisplayInfo()
        {
            Console.WriteLine(
                "++++++++++++++++++++++++++++++++++++\n" +
                "\t\tBookSHelf\n\n" +
                $"Author: {Author}\n" +
                $"Title: {Title}\n" +
                $"Year: {Year}\n" +
                $"++++++++++++++++++++++++++++++++++++\n");
        }
    }
    enum Operation
    {
        Add = 1,
        Subtract,
        Multiply,
        Divide
    }
    partial class Test
    {
        public Test(string name) : base(name, answers, questions)
        {
        }
        public override void SayHello()
        {
            Console.WriteLine("This is a exam!!!!");
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            {
                //Experement Ex1 = new Experement("Вася", "йод", "крахмал");
                //Experement Ex2 = new Experement("Петя", "Ba", "SO4");
                //Console.WriteLine("\t\tЭКСПЕРЕМЕНТЫ!\n");
                //Console.WriteLine("{0} + {1} = {2} ", Ex1.ParamA, Ex1.ParamB, Ex1.Result());
                //Ex1.Display();
                //Console.WriteLine("{0} + {1} = {2} ", Ex2.ParamA, Ex2.ParamB, Ex2.Result());
                //Ex2.Display();
                //Test t1 = new Test("Игрек");
                //t1.Questions();
                //t1.Display();
                //Exam e1 = new Exam("Виталик");
                //Console.WriteLine(e1.ToString());
                //e1.Questions();
                //e1.Display();
                //e1.ChangeName("Гришка");
                //Console.WriteLine(e1.GetName());
                //FinalExam fe1 = new FinalExam("ВОвчик");
                //if (!(e1 is Question qst1))
                //{
                //    Console.WriteLine("Преобразование прошло неудачно");
                //}
                //else
                //{
                //    qst1.SayHello();
                //}
            }
            //lab6
            Library BSTULib = new Library();
            BSTULib.Author = "Артур Конан Дойль";
            BSTULib.Title = "Шерлок Холмс";
            BSTULib.Year = 1891;
            BSTULib.DisplayInfo();
            Operation now;
            double result = 0.0;
            int x = 5, y = 6;
            now = Operation.Add; //Subtract, Multiply, Divide
            switch (now)
            {
                case Operation.Add:
                    result = x + y;
                    break;
                case Operation.Subtract:
                    result = x - y;
                    break;
                case Operation.Multiply:
                    result = x * y;
                    break;
                case Operation.Divide:
                    result = x / y;
                    break;
            }
            Console.WriteLine("Результат операции равен {0}", result);

            Session[] SessionsArray = new Session[] { new Zachet("Математика",5), new Examen("Психология",2)};
            MySession_Controller controller = new MySession_Controller(SessionsArray);
            controller.Add(new Zachet("Инженерка",2));
            controller.PrintSession();
            Console.WriteLine("Удалил один предмет в сессии: ");
            controller.RemoveAt(1);
            controller.PrintSession();
            controller.QueTest(2);
            controller.Espitanii();
        }
    }
}