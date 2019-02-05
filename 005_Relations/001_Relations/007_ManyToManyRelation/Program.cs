using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

// пример использования связей для вывода информации о продажах

namespace ReLationExample
{
    class Program
    {
        static void Main(string[] args)
        {
            DataSet shopDB = new DataSet();

            shopDB.ReadXmlSchema(@"D:\ADO.NET\DATA\ShopDbSchema.xml"); // чтение схемы базы данных ShopDB
            shopDB.ReadXml(@"D:\ADO.NET\DATA\ShopDBData.xml"); // чтение данных базы данных ShopDB

            // получение ссылок на таблицы
            var customers = shopDB.Tables["Customers"];
            var orders = shopDB.Tables["Orders"];
            var orderDetails = shopDB.Tables["OrderDetails"];
            var products = shopDB.Tables["Products"];

            ShowCustomersInfo(customers);
        }

        // создание метода, выводящего данные о продажах 
        private static void ShowCustomersInfo(DataTable customers)
        {
            foreach (DataRow customer in customers.Rows)
            {
                if (customer.GetChildRows("Customers_Orders").Length != 0)
                {
                    Console.WriteLine("{0} {1} {2}", customer[2], customer[1], customer[3]);
                    Console.WriteLine();

                    foreach (DataRow order in customer.GetChildRows("Customers_Orders"))
                    {
                        Console.WriteLine("\t OrderID:{0}, {1:D}", order["OrderID"], order["OrderDate"]);
                        foreach (DataRow orderDetail in order.GetChildRows("orders_OrderDetails"))
                        {
                            DataRow product = orderDetail.GetParentRow("Products_OrderDetails");

                            Console.WriteLine("\t\t LineItem:{0} - {2}, {1:C}",
                                                orderDetail["LineItem"],
                                                orderDetail["TotalPrice"],
                                                product["Description"].ToString().Trim());
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine(new string('-', 20));
                }
            }
        }
    }
}
