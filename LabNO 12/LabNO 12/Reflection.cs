using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;


namespace LabNO_12
{
    public static class Reflection
    {
        public static void WriteClassInFile(string name)
        {
            try
            {

                using (StreamWriter sw = new StreamWriter(@"E:\Учеба\БГТУ\2 курс\1 семестр\ООП\Labs\LabNO 12\file.txt", false, System.Text.Encoding.Default))
                {
                    Type type = Type.GetType(name);

                    sw.WriteLine($"Тип класса - {type}");

                    foreach (MemberInfo mi in type.GetMembers())
                    {
                        string a = mi.DeclaringType + " " + mi.MemberType + " " + mi.Name;
                        sw.WriteLine(a);
                    }
                    Console.WriteLine("Данные записаны в файл");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void GetPublicMethods(string name)
        {
            Console.WriteLine("\n\nВсе общедоступные публичные методы класса:");
            Type type = Type.GetType(name);
            Console.WriteLine("Методы:");
            foreach (MethodInfo method in type.GetMethods())
            {
                string modificator = "";
                if (method.IsStatic)
                    modificator += "static ";
                if (method.IsVirtual)
                    modificator += "virtual ";
                Console.Write(modificator + method.ReturnType.Name + " " + method.Name + " (");
                //получаем все параметры
                ParameterInfo[] parameters = method.GetParameters();
                for (int i = 0; i < parameters.Length; i++)
                {
                    Console.Write(parameters[i].ParameterType.Name + " " + parameters[i].Name);
                    if (i + 1 < parameters.Length) Console.Write(", ");
                }
                Console.WriteLine(")");
            }
        }
        public static void GetFieldAndProperty(string name)
        {
            Type type = Type.GetType(name);
            Console.WriteLine("\n\nПоля:");
            foreach(FieldInfo fi in type.GetFields())
            {
                Console.WriteLine($"{fi.FieldType} {fi.Name}");
            }
            Console.WriteLine("\n\nСвойства:");
            foreach(PropertyInfo pi in type.GetProperties())
            {
                Console.WriteLine($"{pi.PropertyType} {pi.Name}");
            }
        }
        public static void GetInterfaces(string name)
        
{
            Type type = Type.GetType(name);
            Console.WriteLine("\n\nВсе реализованные классом интерфейсы:");
            foreach(Type ti in type.GetInterfaces())
            {
                Console.WriteLine(ti.Name
);
            }
        }
        public static void GetMethodsName(string name)
        {
            Type type = Type.GetType(name);
            Console.WriteLine("\n\nВведите тип параметра для запрашеваемого метода: ");
            string typeName = Console.ReadLine();
            Console.WriteLine("Найденные методы:");
            foreach(MethodInfo mi in type.GetMethods())
            {
                ParameterInfo[] parameters = mi.GetParameters();
                foreach(ParameterInfo pi in parameters)
                {
                    if(pi.ParameterType.Name == typeName)
                    {
                        Console.WriteLine(mi.Name + "(" + pi.ParameterType.Name + " " + pi.Name + ")");
                    }
                }
            }
        }
        public static void CallMethod(string className, string methodName)
        {
            Console.WriteLine("\n\nВызов метода через некоторый метод класса:");
            try
            {
                using (StreamReader sr = new StreamReader(@"E:\Учеба\БГТУ\2 курс\1 семестр\ООП\Labs\LabNO 12\Parameters.txt", System.Text.Encoding.Default))
                {
                    string param;
                    param = sr.ReadLine();


                    Type t = Type.GetType(className, true, true);

                    // создаем экземпляр класса 
                    object obj = Activator.CreateInstance(t);

                    // получаем метод GetResult
                    MethodInfo method = t.GetMethod(methodName);

                    // вызываем метод, передаем ему значения для параметров и получаем результат
                    object result = method.Invoke(obj, new object[] { param });
                    Console.WriteLine((result));

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
