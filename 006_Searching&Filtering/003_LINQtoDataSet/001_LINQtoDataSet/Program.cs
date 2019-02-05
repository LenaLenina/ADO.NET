using System;
using System.Linq;
using System.Data;
using System.Data.SqlClient;

// Создание LINQ запросов для объектов DataTable

namespace LINQtoDataSet
{
    class Program
    {
        static void Main(string[] args)
        {
            DataSet ShopDB = new DataSet();

            ShopDB.ReadXmlSchema(@"D:\ADO.NET\DATA\ShopDbSchema.xml");
            ShopDB.ReadXml(@"D:\ADO.NET\DATA\ShopDbData.xml");

            DataTable customers = ShopDB.Tables["Customers"];

            var query = from customer in customers.AsEnumerable() // по умолчанию объекты DataTable не реализуют интерфейс IEnumerable
                        select new { FName = customer["FName"], LName = customer["LName"] };

            foreach (var customerInfo in query)
            {
                Console.WriteLine(customerInfo.LName +" "+ customerInfo.FName);
            }
        }
    }
}
