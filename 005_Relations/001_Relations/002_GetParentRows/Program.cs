using System;
using System.Data;
using System.Data.SqlClient;

// Просмотр дочерних строк. Метод GetChildRows()

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

            // создание связи таблицы Customers с таблицей Orders
            shopDB.Relations.Add("Customers_Orders", customers.Columns["CustomerNo"], orders.Columns["CustomerNo"]); 

            foreach (DataRow customerRow in customers.Rows)
            {
                // метод GetChaildRows получает дочерние строки в виде массива DataRow[]
                DataRow[] chilRows = customerRow.GetChildRows("Customers_Orders"); 

                if (chilRows.Length != 0) // если существуют дочерние записи
                {
                    Console.WriteLine("{0} {1} {2}", customerRow[2], customerRow[1], customerRow[3]);
                    
                    foreach (DataRow ordersRow in chilRows)
                        Console.WriteLine("\tOrderId: {0}, OrderDate: {1};", ordersRow["OrderID"], ordersRow["OrderDate"]);

                    Console.WriteLine();
                }
            }
        }
    }
}
