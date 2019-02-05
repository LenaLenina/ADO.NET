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
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            adapter.Fill(customers);

            //*********************************************Adding Data******************************************

            customers.LoadDataRow(new object[] { -1, "TEST", "TEST", "TEST", "TEST", "TEST", "TEST", "TEST", "9999/12/31" }, false);

            adapter.Update(customers);

            customers.Clear();
            adapter.Fill(customers);

            Console.WriteLine("Customers after adding test rows");
            
            foreach (DataRow row in customers.Rows)
            {
                foreach (DataColumn column in customers.Columns)
                    Console.WriteLine("{0}: {1}", column.ColumnName, row[column]);

                Console.WriteLine();
            }
            Console.ReadKey();
            Console.Clear();


            //*********************************************Changing Data******************************************

            DataRow[] changedRows = customers.Select("Phone = 'TEST'");

            foreach (var singleRow in changedRows)
            {
                singleRow[1] = "ChangedValue";
                singleRow[2] = "ChangedValue";
                singleRow[3] = "ChangedValue";
            }

            adapter.Update(customers);

            customers.Clear();
            adapter.Fill(customers);

            Console.WriteLine("Customers after changing test rows");

            foreach (DataRow row in customers.Rows)
            {
                foreach (DataColumn column in customers.Columns)
                    Console.WriteLine("{0}: {1}", column.ColumnName, row[column]);

                Console.WriteLine();
            }

            Console.ReadKey();
            Console.Clear();


            //*********************************************Deleting Data******************************************
            DataRow[] rowsToDelete = customers.Select("Phone = 'TEST'");

            foreach (var singleRow in rowsToDelete)
            {
                singleRow.Delete();
            }

            adapter.Update(customers);

            customers.Clear();
            adapter.Fill(customers);

            Console.WriteLine("Customers after deleting test rows");

            foreach (DataRow row in customers.Rows)
            {
                foreach (DataColumn column in customers.Columns)
                    Console.WriteLine("{0}: {1}", column.ColumnName, row[column]);

                Console.WriteLine();
            }

            Console.ReadKey();
            Console.Clear();
        }


    }
}