using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RelationsWork.ShopDBTableAdapters;

namespace RelationsWork
{
    class Program
    {
        static void Main(string[] args)
        {
            ShopDB shopDB = new ShopDB();

            new CustomersTableAdapter().
                Fill(shopDB.Customers);
            new OrdersTableAdapter().
                Fill(shopDB.Orders);
            new OrderDetailsTableAdapter().
                Fill(shopDB.OrderDetails);
            new ProductsTableAdapter().
                Fill(shopDB.Products);

            foreach (var customer in shopDB.Customers)
            {
                var orders = customer.GetOrdersRows();

                if (orders.Length > 0)
                {
                    Console.WriteLine("{0} {1} {2}", customer.LName, customer.FName, customer.MName);
                    Console.WriteLine();

                    foreach (var order in orders)
                    {
                        Console.WriteLine("\tOrderId:{0}, {1}", order.OrderID, order.OrderDate);
                        foreach (var orderDetail in order.GetOrderDetailsRows())
                        {
                            var product = orderDetail.ProductsRow;

                            Console.WriteLine("\t\tLineItem:{0} - {1}, {2:C}",
                                orderDetail.LineItem, product.Description.Trim(), orderDetail.TotalPrice);
                        }
                        Console.WriteLine();
                    }
                }
            }

        }
    }
}
