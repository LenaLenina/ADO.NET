using System;
using System.Data;
using System.Data.SqlClient;

// Работа с реляционными данными в строго типизированном DataSet

namespace GetChanges
{
    class Program
    {
        static void Main(string[] args)
        {
            DataSet simpleShopDb = new DataSet();

            simpleShopDb.ReadXmlSchema(@"D:\ADO.NET\DATA\ShopDbSchema.xml");
            simpleShopDb.ReadXml(@"D:\ADO.NET\DATA\ShopDBData.xml");

            ShopDB strongedShopDB = new ShopDB();

            strongedShopDB.Customers.Merge(simpleShopDb.Tables["Customers"]);
            strongedShopDB.Orders.Merge(simpleShopDb.Tables["Orders"]);

            var selectedCustomer = strongedShopDB.Customers.FindByCustomerNo(1);

            Console.WriteLine("{0} {1} {2}", selectedCustomer.LName, selectedCustomer.FName, selectedCustomer.MName+"\n");
            foreach (var ordersRow in selectedCustomer.GetOrdersRows())
            {
                Console.WriteLine("\tOrderID: "+ordersRow.OrderID);
                Console.WriteLine("\tOrderdate: "+ordersRow.OrderDate);
                Console.WriteLine();
            }
        }
    }
}
