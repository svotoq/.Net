using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labNo_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Experement Ex1 = new Experement("Вася", "йод", "крахмал");
            Experement Ex2 = new Experement("Петя", "Ba", "SO4");
            Console.WriteLine("\t\tЭКСПЕРЕМЕНТЫ!\n");
            Console.WriteLine("{0} + {1} = {2} ", Ex1.ParamA, Ex1.ParamB, Ex1.Result());
            Ex1.Display();
            Console.WriteLine("{0} + {1} = {2} ", Ex2.ParamA, Ex2.ParamB, Ex2.Result());
            Ex2.Display();
            Test t1 = new Test("Игрек");
            t1.Questions();
            t1.Display();
            Exam e1 = new Exam("Виталик");
            Console.WriteLine(e1.ToString());
            e1.Questions();
            e1.Display();
            e1.ChangeName("Гришка");
            Console.WriteLine(e1.GetName());
            FinalExam fe1 = new FinalExam("ВОвчик");
            if (!(e1 is Question qst1))
            {
                Console.WriteLine("Преобразование прошло неудачно");
            }
            else
            {
                qst1.SayHello();
            }
        }
    }
}
