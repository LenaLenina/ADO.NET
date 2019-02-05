using System;
using System.Data.SqlClient;
using System.Data;

// Возможности сортировки с помощью метода Select

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

            DataRow[] customersRows = customers.Select("City = 'Киев'", "DateInSystem desc");

            foreach (var customersRow in customersRows)
            {
                foreach (DataColumn customersColumn in customers.Columns)
                    Console.WriteLine(customersColumn.ColumnName + " " + customersRow[customersColumn]);

                Console.WriteLine();
            }
        }
    }
}
