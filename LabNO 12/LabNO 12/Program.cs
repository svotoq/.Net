using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabNO_12
{
    class Program
    {
        static void Main(string[] args)
        {
            Reflection.WriteClassInFile("LabNO_12.Circle");
            Reflection.GetPublicMethods("LabNO_12.Circle");
            Reflection.GetFieldAndProperty("LabNO_12.Circle");
            Reflection.GetInterfaces("LabNO_12.Circle");    
            Reflection.GetMethodsName("LabNO_12.Circle");
            Reflection.CallMethod("LabNO_12.Circle", "Info");
        }
    }
}
