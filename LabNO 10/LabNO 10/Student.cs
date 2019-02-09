using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabNO_10
{
    class Student : IComparable<Student>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Faculty { get; set; }
        public int Course { get; set; }
        public int Group { get; set; }
        public Student(string Name, int Age, string Faculty, int Course, int Group)
        {
            this.Name = Name;
            this.Age = Age;
            this.Faculty = Faculty;
            this.Course = Course;
            this.Group = Group;
        }

        public Student()
        {
        }
        public override string ToString()
        {
            return $"Имя: {Name}\n" +
                $"Возраст: {Age}\n" +
                $"Факультет: {Faculty}\n" +
                $"Курс: {Course}\n" +
                $"Группа: {Group}\n";
        }
        public void DisplayInfo()
        {
            Console.WriteLine("====Студент====\n" +
                $"Имя: {Name}\n" +
                $"Возвраст: {Age}\n" +
                $"Факультет: {Faculty}\n" +
                $"Курс: {Course}\n" +
                $"Группа: {Group}\n" +
                "===============");
        }

        public int CompareTo(Student obj)
        {
            if (this.Age > obj.Age)
            {
                return 1;
            }
            if (this.Age < obj.Age)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
        
    }
}
