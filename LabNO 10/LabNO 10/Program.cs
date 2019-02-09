using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.ObjectModel;


namespace LabNO_10
{
    class Program
    {
        static void Main(string[] args)
        {
            for (; ; )
            {
                Console.Clear();
                Console.WriteLine("1 - Задание 1\n" +
                    "2 - Задание 2\n" +
                    "3 - Задание 3\n" +
                    "4 - Задание 4\n" +
                    "0 - Выход");
                if (int.TryParse(Console.ReadLine(), out int result))
                {
                    switch (result)
                    {
                        case 1: Console.Clear(); Zad1(); break;
                        case 2: Console.Clear(); Zad2(); break;
                        case 3: Console.Clear(); Zad3(); break;
                        case 4: Console.Clear(); Zad4(); break;
                        case 0: return;
                    }
                }
            }
        }
        private static void Zad1()
        {
            ArrayList alCollection = new ArrayList(10);
            Random rand = new Random();
            int amountOfInt = 5;// количество целых чисел
            for (int i = 0; i < amountOfInt; i++) //добавляем целые числа в коллекцию
            {
                alCollection.Add(rand.Next(-2, 5));
            }
            alCollection.Add("Строка"); //добавляем строку
            Student Ivan = new Student("Иван", 18, "ЛХ", 2, 3);
            Ivan.DisplayInfo();//Выводим информацию об иване
            alCollection.Add(Ivan);//добавляем Ивана в коллекцию
            Console.WriteLine("Номер элемента который хотите удалить?");
            for (int i = 0; i < alCollection.Count; i++)
            {
                Console.WriteLine($"Элемент {i}: {alCollection[i]}");
            }
            if (int.TryParse(Console.ReadLine(), out int objForRemove) && objForRemove < alCollection.Count)
            {
                alCollection.RemoveAt(objForRemove);
            }
            else
            {
                Console.WriteLine("Ошибочка, нет такого элемента!");
            }
            Console.WriteLine("===Коллекция===");
            Console.WriteLine($"Количество элементов: {alCollection.Count}");
            foreach (object CurrentObject in alCollection)
            {
                Console.WriteLine(CurrentObject);
            }
            Console.WriteLine("============");
            Console.WriteLine("Поиск элемента в коллекции\n" +
                "Введите индекс элемента:");
            if (int.TryParse(Console.ReadLine(), out int index) && index < alCollection.Count)
            {
                for (int i = 0; i < alCollection.Count; i++)
                {
                    if (i == index)
                    {
                        Console.WriteLine("Элемент найден: " + alCollection[i]);
                    }
                }
            }
            else
            {
                Console.WriteLine($"Ошибка. В коллекции всего {alCollection.Count} элементов!");
            }
            Console.ReadKey();
        }
        private static void Zad2()
        {
            SortedDictionary<int, string> sdCollection = new SortedDictionary<int, string>
            {
                { 0, "Первый элемент" },
                { 1, "Второй элемент" },
                { 2, "Третий элемент" },
                { 3, "Четвертый элемент" },
                { 4, "Пятый элемент" },
                { 5, "Шестой элемент" }
            };
            ICollection<int> keys = sdCollection.Keys;
            OutPut(sdCollection, keys);
            Console.WriteLine("Сколько элементов удалить?");
            if (int.TryParse(Console.ReadLine(), out int countToDel) && countToDel < sdCollection.Count)
            {
                for (int i = 0; i < countToDel; i++)
                {
                    sdCollection.Remove(i);
                }
            }
            else
            {
                Console.WriteLine("Ошибочка, нету стольки элементов в sdCollection");
            }
            sdCollection.Add(7, "Добавленный элемент");
            OutPut(sdCollection, keys);
            List<string> lCollection = new List<string>();
            foreach (int currentIndex in keys)
            {
                lCollection.Add(sdCollection[currentIndex]);
            }
            OutPut(lCollection);
            Console.WriteLine("Введите строку для поиска");
            Console.WriteLine("Индекс элемента: " + lCollection.IndexOf(Console.ReadLine()));
            Console.ReadKey();
        }
        private static void Zad3()
        {
            SortedDictionary<int, Student> sdCollection = new SortedDictionary<int, Student>
            {
                { 0, new Student("Иван", 20, "ХТиТ", 4, 6) },
                { 1, new Student("Вася", 19, "ФИТ", 3, 2) },
                { 2, new Student("Юля", 17, "ФИТ", 1, 9) }
            };
            ICollection<int> keys = sdCollection.Keys;
            OutPut(sdCollection, keys);
            Console.WriteLine("Сколько элементов удалить?");
            if (int.TryParse(Console.ReadLine(), out int countToDel) && countToDel < sdCollection.Count)
            {
                for (int i = 0; i < countToDel; i++)
                {
                    sdCollection.Remove(i);
                }
            }
            else
            {
                Console.WriteLine("Ошибочка, нету стольки элементов в sdCollection");
            }
            sdCollection.Add(7, new Student("Влад", 17, "ЛХ", 1, 6));
            OutPut(sdCollection, keys);
            List<Student> lCollection = new List<Student>();
            foreach (int currentIndex in keys)
            {
                lCollection.Add(sdCollection[currentIndex]);
            }
            lCollection.Sort();
            OutPut(lCollection);
            Console.WriteLine("ПОИСК!\nВведите имя");
            string nameToSearch = Console.ReadLine();
            Console.WriteLine(lCollection.FindIndex(r => r.Name.Equals(nameToSearch)));
            Console.ReadKey();
        }
        private static void Zad4()
        {
            ObservableCollection<Student> oCollection = new ObservableCollection<Student>();
            oCollection.CollectionChanged += CollectionChanged;
            oCollection.Add(new Student());
            oCollection.Add(new Student("Иван", 20, "ХТиТ", 4, 6));
            oCollection.RemoveAt(1);
            Console.ReadKey();
        }
        private static void OutPut<T, V>(SortedDictionary<V, T> sdCollection, ICollection<V> keys)
        {
            Console.WriteLine($"==Вывод sdCollection==");
            foreach (V currentIndex in keys)
            {
                Console.WriteLine($"ID--> {currentIndex}\n{sdCollection[currentIndex]}\n");
            }
            Console.WriteLine("======================");

        }
        private static void OutPut<T>(List<T> lCollection)
        {
            Console.WriteLine($"==Вывод lCollection==");
            foreach (T CurrentObject in lCollection)
            {
                Console.WriteLine(CurrentObject);
            }
            Console.WriteLine("======================");
        }
        private static void CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine("Коллекция изменена!");
        }
    }
}

