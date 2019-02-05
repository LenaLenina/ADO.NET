using System;
using System.Data;
using System.Data.SqlClient;

// Заполнение

namespace GetPartOfRows
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=ShopDB;Integrated Security=True";
            string commandString = "SELECT * FROM Customers";

            DataTable table = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter(commandString, connectionString);

            int step = 2;

            for (int i = 0; adapter.Fill( i, step, table) > 0; i += step)
            {
                Console.WriteLine(table.Rows.Count);

                foreach (DataRow row in table.Rows)
                {
                    foreach (DataColumn col in table.Columns)
                        Console.WriteLine("{0} {1}", col.ColumnName, row[col]);
                    
                    Console.WriteLine();
                }

                Console.ReadKey();
                Console.Clear();
            }

        }
    }
}
