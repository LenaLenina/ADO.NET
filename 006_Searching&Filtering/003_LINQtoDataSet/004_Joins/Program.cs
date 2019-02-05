using System;
using System.Data.SqlClient;
using System.Data;
using System.Linq;

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
            var orderDetails = ShopDB.Tables["OrderDetails"];
            var products = ShopDB.Tables["Products"];

            var query = from customer in customers.AsEnumerable()
                        from order in orders.AsEnumerable()
                        from orderDetail in orderDetails.AsEnumerable()
                        from product in products.AsEnumerable()

                        where (int)customer["CustomerNo"] == (int)order["CustomerNo"] &&
                              (int)order["OrderId"] == (int)orderDetail["OrderId"] &&
                              (int)orderDetail["ProdID"] == (int)product["ProdID"]

                        select new { Customer = new { FName = customer["FName"], LName = customer["LName"], MName = customer["MName"] },
                                     OrderDate = order["OrderDate"], LineItem = orderDetail["LineItem"], TotalPrice = order["TotalPrice"], Description = product["Description"]};


            foreach (var info in query)
            {
            }
        }
    }
}
