using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LabNO_8
{
    public class CollectionType<T> : IOperations<T> where T : struct
    {
        private T[] arr;
        private static int i = 0;
        public CollectionType()
        {
            this.arr = new T[0];
        }
        public CollectionType(int size) : this()
        {
            this.arr = new T[size];
        }
        //получение и присвоение данных по индексу
        public T this[int index]
        {
            get
            {
                return arr[index];
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
        public int Count { get => this.arr.Length; }
        public CollectionType<T> Add(T obj, int index)
        {
            int BuffCount = Count - 1;//массив с 0, значит индекс 4 равен позиции 5 в массиве
            CollectionType<T> res = new CollectionType<T>(Count + 1);
            try
            {
                if (index > BuffCount && index - BuffCount != 1)
                {
                    throw new IndexOutOfRangeException();
                }
            }
            catch (IndexOutOfRangeException)
            {
                do
                {
                    index--;
                } while (index - BuffCount != 1);
            }
            finally
            {
                res[index] = obj;
                for (int i = 0, j = 0; i < Count; i++, j++)
                {
                    res[i] = arr[i];
                }
            }
            return res;
        }
        public CollectionType<T> Delete(T obj)
        {
            CollectionType<T> res;
            int NewCount = Count - 1;
            try
            {
                int equals = 0; // проверяем есть ли свопадение
                for (int i = 0; i < Count; i++)
                {
                    if (arr[i].Equals(obj))
                    {
                        equals++;
                    }
                }
                if (equals == 0)
                {
                    throw new ElementNotFound();
                }
            }
            catch (ElementNotFound)
            {
                NewCount = Count;
                Console.WriteLine("Такой элемент не найден! Массив возвращен в исходном состоянии!");
            }
            finally
            {
                res = new CollectionType<T>(NewCount);
                if (NewCount == Count)
                {
                    for (int i = 0; i < Count; i++)
                    {
                        res[i] = arr[i];
                    }
                }
                else
                {
                    for (int i = 0; i < Count; i++)
                    {
                        if (arr[i].Equals(obj))
                        {
                            for (int j = 0; j < Count; j++)
                            {
                                if (j != i)
                                {
                                    res[j] = arr[j];
                                }
                            }
                        }
                    }
                }
            }
            return res;
        }
        public void Show()
        {
            for (int i = 0; i < Count; i++)
            {
                Console.Write(arr[i]);
            }
            Console.WriteLine();
        }
        public void Read()//чтение из файла
        {
            String line;
            try
            {
                StreamReader sr = new StreamReader("C:\\Users\\svoto\\Desktop\\Sample.txt");
                line = sr.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Исключение: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Данные считаны!");
            }
        }
        public void Write()//запись в файл
        {
            string str = "";
            for (int i = 0; i < Count; i++)
            {
                str += Convert.ToString(arr[i]);
            }
            try
            {
                StreamWriter sw = new StreamWriter("C:\\Users\\svoto\\Desktop\\Sample.txt");
                sw.WriteLine(str);
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Исеключение: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Данные успешно записаны!");
            }
        }
    }

    class ElementNotFound : Exception
    {
    }
}
