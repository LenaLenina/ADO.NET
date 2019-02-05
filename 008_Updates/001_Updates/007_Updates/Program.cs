using System;
using System.Data;
using System.Data.SqlClient;

namespace Updates
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=ShopDB;Integrated Security=True";
            string commandString = "SELECT * FROM Customers";

            DataTable customers = new DataTable("Customers");

            SqlDataAdapter adapter = new SqlDataAdapter(commandString, connectionString);
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            ConfigureCustomersAdapter(adapter);
            adapter.Fill(customers);

            DataRow[] rowsToDelete = customers.Select("Phone = 'TEST'");

            foreach (var row in rowsToDelete)
            {
                row.Delete();
            }

            adapter.Update(customers);

            foreach (DataRow row in customers.Rows)
            {
                foreach (DataColumn column in customers.Columns)
                    Console.WriteLine("{0}: {1}", column.ColumnName, row[column]);

                Console.WriteLine();
            }

        }

        private static void ConfigureCustomersAdapter(SqlDataAdapter customersAdapter)
        {
            customersAdapter.DeleteCommand = new SqlCommand("DELETE Customers WHERE CustomerNo = @CustomerNo",
                                             customersAdapter.SelectCommand.Connection);

            var insertParameters = customersAdapter.DeleteCommand.Parameters;
            insertParameters.Add("@CustomerNo", SqlDbType.Int, 0, "CustomerNo");
        }
    }
}
