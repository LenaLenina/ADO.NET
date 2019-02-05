using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;

// Перекресные запросы между таблицами LINQ to DataSet

namespace Joins
{
    class Program
    {
        static void Main(string[] args)
        {
            DataSet ShopDB = new DataSet();

            ShopDB.ReadXmlSchema(@"D:\ADO.NET\DATA\ShopDbSchema.xml");
            ShopDB.ReadXml(@"D:\ADO.NET\DATA\ShopDbData.xml");

            var customers = ShopDB.Tables["Customers"];
            var orders = ShopDB.Tables["Orders"];

            var inner = from customer in customers.AsEnumerable() // InnerJoin
                        join order in orders.AsEnumerable()
                        on customer["CustomerNo"] equals order["CustomerNo"]
                        select new { Fname = customer["FName"], LName = customer["LName"], OrderDate = order["OrderDate"] };

            var outer = from customer in customers.AsEnumerable() // OuterJoin
                         join order in orders.AsEnumerable()
                         on customer["CustomerNo"] equals order["CustomerNo"] into joinGroup
                         select new { Fname = customer["FName"], LName = customer["LName"], OrderDate = joinGroup };

            foreach (var item in inner)
            {
                Console.WriteLine("{2:D} {1} {0}", item.LName, item.Fname, item.OrderDate);
            }

            Console.WriteLine(new string('-', 20));
            foreach (var item in outer)
            {
                Console.WriteLine("{1} {0}", item.LName, item.Fname);
                foreach (var item2 in item.OrderDate)
                {
                    Console.WriteLine("\t" + item2["OrderDate"]);
                }
                Console.WriteLine();
            }

        }
    }
}
