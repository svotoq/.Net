using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabNO_11
{
    class Circle
    {
        public int CenterX { get; set; }
        public int CenterY { get; set; }
        public int Radius { get; set; }
        private const double PI = 3.14;
        public Circle()
        {
        }
        public double Сircumference()
        {
            return 2 * PI * Radius;
        }
        public double Area()
        {
            return PI * Radius * Radius;
        }
        public static Circle operator +(Circle obj1, Circle obj2)
        {
            Circle obj3 = new Circle();
            obj3.Radius = obj1.Radius + obj2.Radius;
            return obj3;
        }
        public override string ToString()
        {
            return $"{CenterX} {CenterY}  {Radius} ";
        }
    }
}
