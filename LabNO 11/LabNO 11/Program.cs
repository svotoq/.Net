using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabNO_11
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] months = new string[12] {
                "January", "February", "March", "April",
                "May", "June", "July", "August",
                "September", "October", "November", "December"};
            //1.1
            Console.Write("Input Lenght: ");
            int length = int.Parse(Console.ReadLine());
            var selectedMonths = from t in months //запрос на длинну
                                 where t.Length == length
                                 select t;
            foreach (string s in selectedMonths)
            {
                Console.WriteLine(s);
            }
            //1.2
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nSummer times - 1\n" +
                "Winter times - 2\n"); //зимние или летние месяцы
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.D1:
                    {
                        Console.WriteLine("Summer");
                        selectedMonths = from t in months //запрос на лето
                                         where t == "June" || t == "July" || t == "Agust"
                                         select t;
                    }
                    break;
                case ConsoleKey.D2:
                    {
                        selectedMonths = from t in months //запрос на зиму
                                         where t == "December" || t == "January" || t == "February"
                                         select t;
                    }
                    break;
                default: break;
            }
            foreach (string s in selectedMonths)
            {
                Console.WriteLine(s);
            }
            //1.3
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nAlphabetical order");
            selectedMonths = from t in months // в Алфавитном порядке
                             orderby t ascending
                             select t;
            foreach (string s in selectedMonths)
            {
                Console.WriteLine(s);
            }
            //1.4
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nContains u and length > 4");
            selectedMonths = from t in months // в Алфавитном порядке
                             where t.Contains("u") && t.Length > 4
                             select t;
            foreach (string s in selectedMonths)
            {
                Console.WriteLine(s);
            }
            //2,3
            List<Circle> circles = new List<Circle>
            {
                new Circle{CenterX =12, CenterY =5, Radius=2 },
                new Circle{CenterX =0, CenterY =0, Radius=5 },
                new Circle{CenterX =8, CenterY =-4, Radius=4 },
                new Circle{CenterX =12, CenterY =11, Radius=4 },
                new Circle{CenterX =12, CenterY =11, Radius=7 },
                new Circle{CenterX =-2, CenterY =2, Radius=5 },
            };
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n Если центры совпадают: ");
            var selectCircles = circles.Where(x => circles.Count(y => (y.CenterY == x.CenterY) && (y.CenterX == x.CenterX)) > 1).Select(z => z).ToList();
            foreach (Circle i in selectCircles)
            {
                Console.WriteLine(i);
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n Наименьший по площади объект: ");
            double min = circles.Min(a => a.Area());
            var Min = circles.FirstOrDefault(a => a.Area() == min);
            Console.WriteLine(Min);
            Console.WriteLine("\n Наибольший по площади объект: ");
            double max = circles.Max(a => a.Area());
            var Max = circles.FirstOrDefault(a => a.Area() == max);
            Console.WriteLine(Max);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Введите радиус: ");
            int rad = int.Parse(Console.ReadLine());
            var selectRadius = from t in circles
                               where t.Radius == rad
                               select t;
            Console.WriteLine("\n Объекты с введенным радиусом: ");
            foreach (Circle i in selectRadius)
            {
                Console.WriteLine(i);
            }
            Console.ForegroundColor = ConsoleColor.White;
            var selectTerm = from t in circles
                             where t.CenterX > 0 && t.CenterY > 0
                             select t;
            Console.WriteLine("\n Объекты в первой четверти: ");
            foreach (Circle i in selectTerm)
            {
                Console.WriteLine(i);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            var SpisokPoArea = from t in circles
                               orderby t.Area()
                               select t;
            Console.WriteLine("\n отсортировано по площади: ");
            foreach (Circle i in SpisokPoArea)
            {
                Console.WriteLine(i);
            }

            //4

            Console.ForegroundColor = ConsoleColor.Yellow;
            int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Console.WriteLine("\n\nЗапрос на агрегирование и условие:");
            var myJquery = array.Where(i => i % 2 == 0).OrderBy(t => t).Aggregate((t, n) => t + n);
            Console.WriteLine(myJquery);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\nЗапрос на проекцию, выбираем радиус:");
            var Radius = from u in circles select u.Radius;
            foreach (int n in Radius)
            {
                Console.WriteLine(n);
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\nЗапрос на упорядочивания убываение по площади:");
            var sort = from u in circles
                       orderby u.Area() descending
                       select u;
            foreach (Circle n in sort)
            {
                Console.WriteLine(n);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n Групировка: ");
            selectCircles = circles.Where(x => circles.Count(y => y.Radius == x.Radius) > 1).Select(z => z).ToList();
            foreach (Circle i in selectCircles)
            {
                Console.WriteLine(i);
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n Кванторы: ");
            bool all = circles.All(i => i.Area() > 5);
            if (all == true)
            {
                Console.WriteLine("Все площади >5");
            }
            else
            {
                Console.WriteLine("Не все площади >5");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n Разность: ");
            string[] soft = { "Microsoft", "Google", "Apple" };
            string[] hard = { "Apple", "IBM", "Samsung" };
            // разность множеств
            var result = soft.Except(hard);

            foreach (string s in result)
            {
                Console.WriteLine(s);
            }
            //Придумайте запрос с оператором Join
            List<Student> studentList = new List<Student>
            {
                new Student {Name="Oleg",Age=19},
                new Student { Name="Stas",Age=19}
            };

            List<Fac> rab = new List<Fac>
            {
                 new Fac{Name ="Fit" },
                 new Fac{Name ="XTIT" }
            };


            var res = studentList.Join(rab, // второй набор
                         p => p.Name, // свойство-селектор объекта из первого набора
                         t => t.Name, // свойство-селектор объекта из второго набора
                         (p, t) => new { Name = p.Name, Age = p.Age, Fac = t.Name }); // результат
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\nИспользование оператора Join в запросе:");
            foreach (var i in res)
            {
                Console.WriteLine(i.Name + " - " + i.Fac);
            }
            Console.ReadKey();

        }
        public class Fac
        {
            public string Name { get; set; }
        }

    }
}
