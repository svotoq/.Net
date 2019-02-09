using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabNO_8
{
    class Program
    {
        static void Main(string[] args)
        {
            CollectionType<int> x = new CollectionType<int>(4);
            x[0] = 0; x[1] = 1; x[2] = 2; x[3] = 3;
            x.Show();
            x = x.Add(9, 10);
            x.Show();
            x = x.Delete(9);
            x.Show();
            x.Write();
            x.Read();
        }
    }
}
