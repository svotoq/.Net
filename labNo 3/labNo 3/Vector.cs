using System;


namespace labNo_3
{
    class Vector
    {
        private int[] array = new int[3];
        private int elemAmount;
        private int status;
        private string name;

        public int Array { get => array[0]; }
        public int ElemAmount { get; set; }
        public int Status { get; private set; }
        public string Name { get; set; }
        static private int amount;
        public int Amount { get => amount; }
        readonly int ID;
        public const string vlados = "Vlados";
        public int this[int index]
        {
            get
            {
                return array[index];
            }
            set
            {
                array[index] = value;
            }
        }

        private int sum(int num)
        {
            return num += array[0];
        }

        public int mumn(ref int num)
        {
            return num * array[0];
        }

        public Vector(int value = 5) : this()
        {
            array[0] = value;
        }

        public Vector() : this("Vector")
        {
            array[0] = 2;
            Name = "belstu";
        }

        public Vector(int value, int index, string name) : this()
        {
            array[index] = value;
            Name = name;
        }

        static Vector()
        {
            Console.WriteLine("Hello world!");
            amount++;
        }


        private Vector(string value)
        {
            Console.WriteLine($"private.{value}");
        }

        public override int GetHashCode()
        { // 269 или 47 простые 
            int hash = 269;
            hash = string.IsNullOrEmpty(Name) ? 0 : Name.GetHashCode();
            hash = (hash * 47) + ID.GetHashCode();
            return hash;
        }

        partial class class1
        {
            public void DoWork()
            {
                Console.WriteLine("Делаю работу");
            }
        }

        partial class class1
        {
            public void GoToLunch()
            {
                Console.WriteLine("Иду на обед");
            }
        }

        public override string ToString()
        {
            return "Type" + base.ToString() + " " + array[0] + ID;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            Vector stud = (Vector)obj;
            return (this.array == stud.array && this.ID == stud.ID);
        }

        public bool Nulls()
        {
            if (array[0] == 0)
                return true;
            else
                return false;
        }
        //    public bool module()
        //    {
        //        if()
        //    }
    }
}
