using System;
using System.Data;
using System.Data.SqlClient;

// сортировка и фильтрация данных с помощью DataView

namespace Filtering
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=ShopDB;Integrated Security=True";
            string commandString = "SELECT * FROM Customers";

            DataTable customers = new DataTable();
            customers.TableName = "Customers";

            SqlDataAdapter adapter = new SqlDataAdapter(commandString, connectionString);

            adapter.Fill(customers);

            // создание DataView c фильтром и сортировкой
            DataView customersView = new DataView(customers, "CustomerNo > 2", "LName, FName", DataViewRowState.Unchanged);

            foreach (DataRowView viewRow in customersView)
            {
                Console.WriteLine("CustomerNo: "+viewRow["CustomerNo"]);
                Console.WriteLine("{0} {1} {2}", viewRow["LName"], viewRow["FName"], viewRow["MName"]);
                Console.WriteLine(viewRow["City"]);
                Console.WriteLine(viewRow["Address1"]);
                Console.WriteLine(viewRow["Phone"]);

                Console.WriteLine();
            }
        }
    }
}
