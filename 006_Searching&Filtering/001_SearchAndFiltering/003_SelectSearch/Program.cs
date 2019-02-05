using System;
using System.Data.SqlClient;
using System.Data;

// поиск данных в таблице по указанному фильтру. Метод Select

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

            DataRow[] customersRows = customers.Select("Address1 = 'Лужная 15'");

            foreach (var customersRow in customersRows)
            {
                foreach (DataColumn customersColumn in customers.Columns)
                    Console.WriteLine(customersColumn.ColumnName + " " + customersRow[customersColumn]);
                
                Console.WriteLine();
            }
        }
    }
}
