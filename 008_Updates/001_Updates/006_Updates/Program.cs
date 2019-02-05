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

            customers.LoadDataRow(new object[] { -1, 
                "TEST", "TEST", "TEST", "TEST", "TEST", "TEST", "TEST", "9999/12/31" }, false);

            adapter.Update(customers);

            customers.Clear();

            adapter.Fill(customers);

            foreach (DataRow row in customers.Rows)
            {
                foreach (DataColumn column in customers.Columns)
                    Console.WriteLine("{0}: {1}", column.ColumnName, row[column]);

                Console.WriteLine();
            }
        }

        private static void ConfigureCustomersAdapter(SqlDataAdapter customersAdapter)
        {
            customersAdapter.InsertCommand = 
            new SqlCommand("INSERT Customers "+
                           "VALUES (@FName, @LName, @MName, @Address1, @Address2, @City, @Phone, @DateInSystem)",
                           customersAdapter.SelectCommand.Connection);

            var insertParameters = customersAdapter.InsertCommand.Parameters;
            insertParameters.Add("FName", SqlDbType.NVarChar, 20, "FName");
            insertParameters.Add("LName", SqlDbType.NVarChar, 20, "Lname");
            insertParameters.Add("MName", SqlDbType.NVarChar, 20, "MName");
            insertParameters.Add("Address1", SqlDbType.NVarChar, 20, "Address1");
            insertParameters.Add("Address2", SqlDbType.NVarChar, 20, "Address2");
            insertParameters.Add("City", SqlDbType.NVarChar, 20, "City");
            insertParameters.Add("Phone", SqlDbType.NVarChar, 20, "Phone");
            insertParameters.Add("DateInSystem",    // имя параметра 
                                 SqlDbType.Date,    // тип данных в источнике 
                                 0,                 // длина столбца
                                 "DateInSystem");   // имя столбца в источнике данных
        }
    }
}
