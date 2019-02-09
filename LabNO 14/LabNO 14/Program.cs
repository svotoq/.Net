using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Xml;
using System.Xml.Linq;

namespace LabNO_14
{
    class Program
    {
        static void Main(string[] args)
        {

            Experement exp = new Experement("Петр", "йод", "крахмал");

            Console.WriteLine("Сериализация и десериализация в бинарный формат, ");
            BinaryFormatter binform = new BinaryFormatter();

            using (FileStream fs = new FileStream(@"E:\Учеба\БГТУ\2 курс\1 семестр\ООП\Labs\LabNO 14\ExpInBin.dat", FileMode.Create))
            {
                binform.Serialize(fs, exp);
                Console.WriteLine("Записано в ExpBin.dat");
            }
            using (FileStream fs = new FileStream(@"E:\Учеба\БГТУ\2 курс\1 семестр\ООП\Labs\LabNO 14\ExpInBin.dat", FileMode.OpenOrCreate))
            {
                Experement exp2 = (Experement)binform.Deserialize(fs);
                Console.WriteLine("Извлечение прошло успешно, результат эксперемента: " + exp2.Result());
            }

            Console.WriteLine("Сериализация и десериализация в SOAP формат, ");
            SoapFormatter soapFormatter = new SoapFormatter();
            using (FileStream fs = new FileStream(@"E:\Учеба\БГТУ\2 курс\1 семестр\ООП\Labs\LabNO 14\ExpInSOAP.dat", FileMode.Create))
            {
                soapFormatter.Serialize(fs, exp);
            }
            using (FileStream fs = new FileStream(@"E:\Учеба\БГТУ\2 курс\1 семестр\ООП\Labs\LabNO 14\ExpInSOAP.dat", FileMode.OpenOrCreate))
            {
                Experement exp2 = (Experement)soapFormatter.Deserialize(fs);
                Console.WriteLine("Извлечение прошло успешно, имя эксперементатора: " + exp2.Name);
            }

            Console.WriteLine("Сериализация и десериализация в XML формат, ");
            XmlSerializer xmlSerExp = new XmlSerializer(typeof(Experement));
            using (FileStream fs = new FileStream(@"E:\Учеба\БГТУ\2 курс\1 семестр\ООП\Labs\LabNO 14\ExpInXML.xml", FileMode.Create))
            {
                xmlSerExp.Serialize(fs, exp);
            }
            using (FileStream fs = new FileStream(@"E:\Учеба\БГТУ\2 курс\1 семестр\ООП\Labs\LabNO 14\ExpInXML.xml", FileMode.OpenOrCreate))
            {
                Experement exp2 = (Experement)xmlSerExp.Deserialize(fs);
                Console.WriteLine("Извлечение прошло успешно, результат эксперемента: " + exp2.Result());
            }

            Console.WriteLine("Сериализация и десериализация в JSON формат, ");
            DataContractJsonSerializer JsonSer = new DataContractJsonSerializer(typeof(Experement));
            using (FileStream fs = new FileStream(@"E:\Учеба\БГТУ\2 курс\1 семестр\ООП\Labs\LabNO 14\ExpInJSON.xml", FileMode.Create))
            {
                JsonSer.WriteObject(fs, exp);
            }
            using (FileStream fs = new FileStream(@"E:\Учеба\БГТУ\2 курс\1 семестр\ООП\Labs\LabNO 14\ExpInJSON.xml", FileMode.OpenOrCreate))
            {
                Experement exp2 = (Experement)JsonSer.ReadObject(fs);
                Console.WriteLine("Извлечение прошло успешно, результат эксперемента: " + exp2.Result());
            }

            Console.WriteLine("\n\nСериализация/десириализация массива объектов");
            XmlSerializer xmlSerExpArr = new XmlSerializer(typeof(Experement[]));
            using (FileStream fs = new FileStream(@"E:\Учеба\БГТУ\2 курс\1 семестр\ООП\Labs\LabNO 14\ExpInXMLArr.xml", FileMode.Create))
            {
                Experement[] experements = new Experement[]
                {
                new Experement("Вова","йод","крахмал"),
                new Experement("ИГОРЬ", "Ba", "SO4"),
                new Experement("Таджик","рука","нога")
                };
                xmlSerExpArr.Serialize(fs, experements);
            }
            using (FileStream fs = new FileStream(@"E:\Учеба\БГТУ\2 курс\1 семестр\ООП\Labs\LabNO 14\ExpInXMLArr.xml", FileMode.OpenOrCreate))
            {
                Experement[] exp2 = (Experement[])xmlSerExpArr.Deserialize(fs);
                foreach (Experement e in exp2)
                {
                    Console.WriteLine($"Эксперементатор: {e.Name}, результат: {e.Result()}");
                }
            }
            //Используя XPath напишите два селектора для вашего XML документа

            Console.WriteLine("\n\nДва селектора с помощью XPath:");
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(@"E:\Учеба\БГТУ\2 курс\1 семестр\ООП\Labs\LabNO 14\ExpInXMLArr.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            Console.WriteLine("Выбор дочерних узлов Experement:");
            XmlNodeList childnodes = xRoot.SelectNodes("*");
            foreach (XmlNode n in childnodes)
                Console.WriteLine(n.OuterXml);
            Console.WriteLine("Выбор всех узлов Name:");
            childnodes = xRoot.SelectNodes("//Experement/Name");
            foreach (XmlNode n in childnodes)
                Console.WriteLine(n.OuterXml);

            //Используя Linq to XML создайте новый xml - документ и напишите несколько запросов.
            //создаем Xml
            XDocument xdoc = new XDocument(
                new XElement("Experements",
                     new XElement("Exp",
                        new XAttribute("number", "1"),
                        new XElement("Name", "Петя"),
                        new XElement("ParamA", "йод"),
                        new XElement("ParamB", "крахмал")),
                        new XElement("Exp",
                        new XAttribute("number", "2"),
                        new XElement("Name", "ЖОРИК"),
                        new XElement("ParamA", "Ba"),
                        new XElement("ParamB", "SO4"))));
            xdoc.Save(@"E:\Учеба\БГТУ\2 курс\1 семестр\ООП\Labs\LabNO 14\Zad4.xml");
            //Создаем на основании данных в xml объекты
            Console.WriteLine("Чей результат эксперемента хотите получить? (Петя/ЖОРИК)");
            string name = Console.ReadLine();
            var items = from ex in xdoc.Element("Experements").Elements("Exp")
                        where ex.Element("Name").Value == name
                        select new Experement
                        {
                            Name = ex.Element("Name").Value,
                            ParamA = ex.Element("ParamA").Value,
                            ParamB = ex.Element("ParamB").Value,
                        };
            foreach(var item in items)
            {
                Console.WriteLine($"{item.Result()}");
            }
        }
    }

}
