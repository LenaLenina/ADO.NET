using System;
using System.Data;
using System.Data.SqlClient;

namespace Updates
{
    static class CustomersUpdates
    {
        private static void InsertCustomers(DataRow customersRow)
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=ShopDB;Integrated Security=True";
            string commandString = "INSERT Customers " +
                                   "VALUES (@FName, @LName, @MName, @Address1, @Address2, @City, @Phone, @DateInSystem) SELECT CustomerNo FROM Customers WHERE CustomerNo = @@IDENTITY";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(commandString, connection);
                cmd.Parameters.AddWithValue("FName", customersRow[1]);
                cmd.Parameters.AddWithValue("LName", customersRow[2]);
                cmd.Parameters.AddWithValue("MName", customersRow[3]);
                cmd.Parameters.AddWithValue("Address1", customersRow[4]);
                cmd.Parameters.AddWithValue("Address2", customersRow[5]);
                cmd.Parameters.AddWithValue("City", customersRow[6]);
                cmd.Parameters.AddWithValue("Phone", customersRow[7]);
                cmd.Parameters.AddWithValue("DateInSystem", customersRow[8]);

                try
                {
                    customersRow.Table.Columns[0].ReadOnly = false;
                    customersRow.SetField<int>(0, (int)cmd.ExecuteScalar());
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    customersRow.Table.Columns[0].ReadOnly = true;
                }
              
                customersRow.AcceptChanges();
            }
        }

        public static void InsertCustomers(DataTable customers)
        {
            foreach (DataRow row in customers.Rows)
            {
                if (row.RowState == DataRowState.Added)
                    InsertCustomers(row);
            }
        }
    }
}
