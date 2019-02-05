using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

// создание расчитываемого столбца, выражение которого строится на связи между таблиц

namespace ReLationExample
{
    class Program
    {
        static void Main(string[] args)
        {

            DataSet shopDB = new DataSet();

            shopDB.ReadXmlSchema(@"D:\ADO.NET\DATA\ShopDbSchema.xml");
            shopDB.ReadXml(@"D:\ADO.NET\DATA\ShopDBData.xml");

            shopDB.AcceptChanges();

            var orders = shopDB.Tables["Orders"];
            var orderDetails = shopDB.Tables["OrderDetails"];

            orders.Columns.Add("TotalSold", typeof(double), "SUM(Child(Orders_OrderDetails).TotalPrice)"); // добавление расчитываемого столбца, используемого связь 

            foreach (DataRow order in orders.Rows)
            {
                Console.WriteLine("OrderId:{0},\nOrderDate:{1},\nTotalSold:{2}", order["OrderID"], order["OrderDate"], order["TotalSold"]);
                Console.WriteLine();
            }
        }
    }
}
