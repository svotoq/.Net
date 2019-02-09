using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labNo_5
{

    sealed class Experement : Person
    {
        private string paramA; public string ParamA { get => paramA; }
        private string paramB; public string ParamB { get => paramB; }
        public Experement(string name, string paramA, string paramB) : base(name)
        {
            this.paramA = paramA;
            this.paramB = paramB;
        }
        public string Result()
        {
            if (paramA.Equals("йод") && paramB.Equals("крахмал"))
            {
                return "синяя жидкость";
            }
            if (paramA.Equals("Ba") && paramB.Equals("SO4"))
            {
                return "осадок BaSO4";
            }
            return "Ничего не вышло:<";
        }
        override public void Display()
        {
            Console.WriteLine("Эксперемент провел: {0}\n", Name);
        }
    }
    partial class Test : Question
    {
        private static string[] answers = { "да", "нет", "нет" };
        private static string[] questions = { "Минск столица Беларуси?(да/нет)", "Вильнюс столица Латвии?(да/нет)", "Шиман ректор факультета ФИТ?(да/нет)" };
    }
    class Exam : Question, INterface
    {
        private string Names;
        private static string[] answers = { "1912", "1067", "384" };
        private static string[] questions = { "В каком году затонул титаник?", "Дата основания Минска?", "32 * 12?" };
        public Exam(string name) : base(name, answers, questions)
        {
            Names = name;
        }
        public void ChangeName(string name)
        {
            Names = name;
        }
        public string GetName()
        {
            return Names;
        }
        new public void SayHello()
        {
            Console.WriteLine("This is a exam!!!!");
        }
        public override string ToString()
        {
            return "Это экзамен!";
        }
    }
    class FinalExam
    {
        public FinalExam(string name)
        {
            GOOD();
        }
        private void GOOD()
        {
            Console.WriteLine("NICE DONE!!!");
        }
    }
    class Question
    {
        public string Name { get; set; }
        private int Correct;
        private int Wrong;
        private float Result;
        private readonly string[] Answers;
        private string[] questions;
        public Question(string name, string[] Answers, string[] questions)
        {
            Name = name;
            this.Answers = Answers;
            this.questions = questions;
        }
        public virtual void SayHello()
        {
            Console.WriteLine("HELLO!");
        }
        private void Check(string value, int index)
        {
            if (value.Equals(Answers[index]))
            {
                Correct++;
            }
            else
            {
                Wrong++;
            }
        }
        public void Questions()
        {
            Console.WriteLine("=========================================");
            Console.WriteLine("Ответьте на следующие вопросы: ");
            for (int i = 0; i < questions.Length; i++)
            {
                Console.WriteLine(questions[i]);
                Check(Console.ReadLine(), i);
            }
            Console.WriteLine("=========================================\n");
        }
        public void Display()
        {
            Result = (float)Correct / (float)(Wrong + Correct) * 100;
            Console.WriteLine(
                "\t\tРезультаты тестирования:\n" +
                $"Тестируемый: {Name}\n" +
                $"Правильных ответов: {Correct}\n" +
                $"Неправильных ответов: {Wrong}\n" +
                $"Результат: {Result}%\n");
        }
    }
    abstract class Person
    {

        public string Name { get; set; }

        public Person(string name)
        {
            Name = name;
        }

        public abstract void Display();
    }

}
