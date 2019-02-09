using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labNO_4
{
    class IntArray
    {
        private int[] arr;
        private static int i = 0;
        public IntArray()
        {
            this.arr = new int[0];
            this.Info = new Owner(i++, "stasyan", "stasyan corp");
        }
        public IntArray(int size) : this()
        {
            this.arr = new int[size];
        }
        //получение и присвоение данных по индексу
        public int this[int index]
        {
            get
            {
                int res = int.MinValue;
                try
                {
                    res = this.arr[index];
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine($"ОШИБКА: в массиве нет {index} элемента");
                }
                return res;
            }
            set
            {
                if (index > -1 && index < this.arr.Length)
                {
                    this.arr[index] = value;
                }
            }
        }
        //Размер массива
        public int count { get => this.arr.Length; }
        public static IntArray operator *(IntArray arr1, IntArray arr2)
        {
            IntArray res = new IntArray();
            if (arr1.count == arr2.count)
            {
                res = new IntArray(arr1.count);
                for (int i = 0; i < res.count; i++)
                {
                    res[i] = arr1[i] * arr2[i];
                }
            }
            else
            {
                Console.WriteLine("Ошибка: массивы разной длинны!");
            }
            return res;
        }
        public static bool operator true(IntArray arr)
        {
            for (int i = 0; i < arr.count; i++)
            {
                if (arr[i] < 0)
                {
                    return false;
                }
            }
            return true;
        }
        public static bool operator false(IntArray arr)
        {
            for (int i = 0; i < arr.count; i++)
            {
                if (arr[i] < 0)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool operator ==(IntArray arr1, IntArray arr2)
        {
            int status = 0;
            if (arr1.count == arr2.count)
            {
                for (int i = 0; i < arr1.count; i++)
                {
                    if (arr1[i] != arr2[i])
                    {
                        status = 1;
                        break;
                    }
                }
            }
            if (status == 0)
                return true;
            return false;
        }
        public static bool operator !=(IntArray arr1, IntArray arr2)
        {
            if (arr1.count == arr2.count)
            {
                for (int i = 0; i < arr1.count; i++)
                {
                    if (arr1[i] != arr2[i])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public static bool operator >(IntArray arr1, IntArray arr2)
        {
            int status1 = 0, status2 = 0;
            if (arr1.count == arr2.count)
            {
                for (int i = 0; i < arr1.count; i++)
                {
                    if (arr1[i] > arr2[i])
                    {
                        status1++;
                    }
                    if (arr1[i] < arr2[i])
                    {
                        status2++;
                    }
                }
            }
            if (status1 > status2)
                return true;
            return false;
        }
        public static bool operator <(IntArray arr1, IntArray arr2)
        {
            int status1 = 0, status2 = 0;
            if (arr1.count == arr2.count)
            {
                for (int i = 0; i < arr1.count; i++)
                {
                    if (arr1[i] > arr2[i])
                    {
                        status1++;
                    }
                    if (arr1[i] < arr2[i])
                    {
                        status2++;
                    }
                }
            }
            if (status1 < status2)
                return true;
            return false;
        }
        public Owner Info;
        public class Date
        {
            private DateTime date;
            public Date()
            {
                date = DateTime.Now;
            }
            public DateTime GetDate { get => this.date; }
        }
    }
    class Owner
    {
        public int id;
        public string name;
        public string org;
        public Owner(int id, string name, string org)
        {
            this.id = id;
            this.name = name;
            this.org = org;
        }
    }
}
