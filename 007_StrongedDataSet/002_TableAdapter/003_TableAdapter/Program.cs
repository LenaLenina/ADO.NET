using System;
using System.Data;
using System.Data.SqlClient;

// Вставака данных в источник с помощью метода Insert типизированной таблицы

namespace TableAdaptersWork
{
    class Program
    {
        static void Main(string[] args)
        {
            var customers = new ShopDB.CustomersDataTable();

            var customersTableAdapter = new ShopDBTableAdapters.CustomersTableAdapter { ClearBeforeFill = true };
            customersTableAdapter.Insert("Test", "Test", "Test", "Test", "Test", "Test", "Test", new DateTime(9999 / 12 / 31));
            
            customers = customersTableAdapter.GetData();

            DataRow[] testRows = customers.Select("Phone = 'Test'");

            foreach (var testRow in testRows)
            {
                foreach (DataColumn customersColumn in customers.Columns)
                    Console.WriteLine("{0}: {1}", customersColumn.ColumnName, testRow[customersColumn]);

            }
            
            //*****************************************************************************************
            Console.WriteLine(new string('-', 20));
            Console.WriteLine("Total test row(s) deleted: " + DeleteTestRows());

            customers = customersTableAdapter.GetData();

            testRows = customers.Select("Phone = 'Test'");

            foreach (var testRow in testRows)
            {
                foreach (DataColumn customersColumn in customers.Columns)
                    Console.WriteLine("{0}: {1}", customersColumn.ColumnName, testRow[customersColumn]);
            }

        }

        private static int DeleteTestRows()
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=ShopDB;Integrated Security=True";
            string commandString = "DELETE Customers WHERE Phone ='Test';";

            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();
            SqlCommand deleCommand = new SqlCommand(commandString, connection);

            int rowsAffected = deleCommand.ExecuteNonQuery();

            connection.Close();

            return rowsAffected;
        }
    }
}

