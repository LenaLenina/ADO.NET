using System;
using System.Data;
using System.Data.SqlClient;

// получение родительской строки относительно дочерней. Метод GetParentRow

namespace GetParentRows
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=ShopDB;Integrated Security=True";
            string commandString = "SELECT * FROM Customers; SELECT * FROM Orders;";

            DataSet shopDB = new DataSet("ShopDB");

            SqlDataAdapter adapter = new SqlDataAdapter(commandString, connectionString);

            adapter.Fill(shopDB);
            DataTable customers = shopDB.Tables[0];
            DataTable orders = shopDB.Tables[1];

            shopDB.Relations.Add("Customers_Orders", customers.Columns["CustomerNo"], orders.Columns["CustomerNo"]);

            foreach (DataRow ordersRow in orders.Rows)
            {
                var customerRow = ordersRow.GetParentRow("Customers_Orders"); // метод GetParrentRow возвращает одну строку

                Console.WriteLine("OrderId: "+ordersRow["OrderID"]+"\n"+
                                  "OrderDate: "+ ordersRow["OrderDate"]+"\n"+
                                  "CustomerName: " + customerRow[2] +" "+ customerRow[1] +" "+ customerRow[3]);

                Console.WriteLine();
            }
        }
    }
}
