using System;
using System.Xml.Linq;

namespace Create_Base
{
    class Program
    {
        static void Main(string[] args)
        {
            BuildXmlDocWithLINQToXml();
         
        }
        private static void BuildXmlDocWithLINQToXml()
        {           
             XDocument doc = new XDocument(
                new XElement("DataBase",
                    new XElement("Medicine",
                        new XAttribute("DrugStoreId", "1"),
                        new XAttribute("MedicineName", "Aspirin"),
                        new XAttribute("DateArrival", "12.07.2019"),
                        new XElement("Amount", "12"),
                        new XElement("Price", "120"),                       
                        new XElement("StoragePeriod", "365")),
                    new XElement("Medicine",
                        new XAttribute("DrugStoreId", "23"),
                        new XAttribute("MedicineName", "Ibuprofen"),
                        new XAttribute("DateArrival", "03.02.2020"),
                        new XElement("Amount", "10"),
                        new XElement("Price", "200"),                     
                        new XElement("StoragePeriod", "365")),
                    new XElement("Medicine",
                        new XAttribute("DrugStoreId", "100"),
                        new XAttribute("MedicineName", "Advil"),
                        new XAttribute("DateArrival", "09.08.2019"),
                        new XElement("Amount", "82"),
                        new XElement("Price", "300"),
                        
                        new XElement("StoragePeriod", "400"))));
            //сохраняем наш документ
            doc.Save("bs.xml");

            XDocument xmlDocument = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("Cars",
                    new XElement("Car", new XAttribute("Id", 101),
                        new XElement("LastName", "Ivanov"),
                        new XElement("BrandCode", 555),
                        new XElement("BrandName", "BMW"),
                        new XElement("Benzine", "A-72"),
                        new XElement("Power", 700),
                        new XElement("BenzineMaxVolume", 2000),
                        new XElement("ResidueBenzine", 1500),
                        new XElement("OilVolume", 1000)),
                    new XElement("Car", new XAttribute("Id", 102),
                        new XElement("LastName", "Petrova"),
                        new XElement("BrandCode", 666),
                        new XElement("BrandName", "Honda"),
                        new XElement("Benzine", "A-91"),
                        new XElement("Power", 400),
                        new XElement("BenzineMaxVolume", 1500),
                        new XElement("ResidueBenzine", 1500),
                        new XElement("OilVolume", 900)),
                    new XElement("Car", new XAttribute("Id", 103),
                        new XElement("LastName", "Smith"),
                        new XElement("BrandCode", 555),
                        new XElement("BrandName", "BMW"),
                        new XElement("Benzine", "B-92"),
                        new XElement("Power", 700),
                        new XElement("BenzineMaxVolume", 2000),
                        new XElement("ResidueBenzine", 2000),
                        new XElement("OilVolume", 950))));
            xmlDocument.Save("Cars.xml");


        }
    }
}
