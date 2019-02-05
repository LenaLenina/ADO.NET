using System;
using System.Data;
using System.Data.SqlClient;

// Создание DataView

namespace ViewData
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

            DataView customersView = new DataView(); // используя коструктор по умолчанию
            customersView.Table = customers;    

            // DataView customersView = new DataView(customers); // используя конструктор с одним параметром

            foreach (DataRowView viewRow in customersView)
            {
                Console.WriteLine("{0} {1} {2}",viewRow["LName"], viewRow["FName"], viewRow["MName"]);
                Console.WriteLine(viewRow["City"]);
                Console.WriteLine(viewRow["Address1"]);
                Console.WriteLine(viewRow["Phone"]);
                
                Console.WriteLine();
            }
        }
    }
}
