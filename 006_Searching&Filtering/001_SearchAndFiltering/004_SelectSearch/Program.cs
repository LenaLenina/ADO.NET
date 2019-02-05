using System;
using System.Data.SqlClient;
using System.Data;

// Поиск данных в таблице с помощью метода Select. Использование логических операторов  

namespace SearchingAndFiltering
{
    class Program
    {
        static void Main(string[] args)
        {
            DataSet ds = new DataSet();

            string connecionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=ShopDB;Integrated Security=True";
            string commandString = "SELECT * FROM Customers";

            SqlDataAdapter adapter = new SqlDataAdapter(commandString, connecionString);

            adapter.Fill(ds);

            DataTable customers = ds.Tables[0];

            DataRow[] customersRows = customers.Select("City = 'Харьков' OR City = 'Чернигов'");

            foreach (var customersRow in customersRows)
            {
                foreach (DataColumn customersColumn in customers.Columns)
                    Console.WriteLine(customersColumn.ColumnName + " " + customersRow[customersColumn]);

                Console.WriteLine();
            }
        }
    }
}
