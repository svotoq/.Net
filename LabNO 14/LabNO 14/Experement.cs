using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace LabNO_14
{
    [Serializable]
    public class Person
    {
        public string Name { get; set; }

        public Person(string name)
        {
            Name = name;
        }
        public virtual void Display()
        {
        }
    }
    [Serializable]
    public class Experement : Person
    {
        public string ParamA;
        public string ParamB;
        public Experement() : base("Жорик")
        {
        }
        public Experement(string name, string paramA, string paramB) : base(name)
        {
            ParamA = paramA;
            ParamB = paramB;
        }
        public string Result()
        {
            if (ParamA.Equals("йод") && ParamB.Equals("крахмал"))
            {
                return "синяя жидкость";
            }
            if (ParamA.Equals("Ba") && ParamB.Equals("SO4"))
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
}
