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
            adapter.Fill(customers);

            DataRow selectedRow = customers.Select("CustomerNo = 1")[0];
            selectedRow["FName"] = "TestValue";

            selectedRow = customers.Select("CustomerNo = 2")[0];
            selectedRow.Delete();

            try
            {
                adapter.Update(customers);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
