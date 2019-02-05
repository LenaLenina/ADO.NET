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
                        join order in orders.AsEnumerable()
                        on customer["CustomerNo"] equals order["CustomerNo"] into ordersGroup

                        from order in ordersGroup
                        join orderDetail in orderDetails.AsEnumerable()
                        on order["OrderID"] equals orderDetail["OrderID"] into orderDetailsGroup

                        from orderDetail in orderDetailsGroup
                        join product in products.AsEnumerable()
                        on orderDetail["ProdId"] equals product["ProdId"] into productsGroup

                        from product in productsGroup
                        select new
                        {
                            Customer = new { FName = customer["FName"], LName = customer["LName"], MName = customer["MName"] },
                            LineItem = orderDetail["LineItem"],
                            OrderDate = order["OrderDate"],
                            Product = product["Description"]
                        };

          
        }
    }
}
