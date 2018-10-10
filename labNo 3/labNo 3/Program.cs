using System;

namespace labNo_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector vec = new Vector(0, 0, "top");
            Vector vec2 = new Vector(5, 0, "super vector");
            Vector vec3 = new Vector(0);
            Vector vec4 = new Vector();
            Vector vec5 = new Vector(2);


            Console.WriteLine(vec.Array);
            Console.WriteLine(vec2.Array);

            Console.WriteLine("vec toString: " + vec.ToString());
            Console.WriteLine("Vec2 hasCode: " + vec2.GetHashCode());
            Console.WriteLine("vec4 hasCode: " + vec4.GetHashCode());
            Console.WriteLine("Equals? " + vec.Equals(vec2));

            Vector[] vecArray = { vec, vec2, vec3, vec4, vec5 };
            foreach (Vector a in vecArray)
            {
                if (a.Nulls())
                    Console.WriteLine("Вектор с нулевым значением: " + a.Name);
            }
            int now = 9999;
            string name = "default";
            foreach (Vector a in vecArray)
            {
                if (a.Array < now)
                {
                    now = a.Array;
                    name = a.Name;
                }
            }
            Console.WriteLine("Минимальный по модулю вектор: " + name);
        }
    }
}
