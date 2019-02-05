using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Updates.Commands
{
    static class CustomersUpdates
    {
        public static void InsertCustomers(DataRow customersRow)
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

        public static void ChangeCustomers(DataRow customersRow)
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=ShopDB;Integrated Security=True";

            StringBuilder builder = new StringBuilder();

            string commandString = "UPDATE Customers " +
                                   "SET FName = @FName," +
                                   "LName = @LName," +
                                   "MName= @Mname," +
                                   "Address1 = @Address1," +
                                   "Address2 = @Address2," +
                                   "City = @City," +
                                   "Phone = @Phone," +
                                   "DateInSystem = @DateInSystem " +
                                   "WHERE CustomerNo = @CustomerNo";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(commandString, connection);
                cmd.Parameters.AddWithValue("CustomerNo", customersRow[0]);
                cmd.Parameters.AddWithValue("FName", customersRow[1]);
                cmd.Parameters.AddWithValue("LName", customersRow[2]);
                cmd.Parameters.AddWithValue("MName", customersRow[3]);
                cmd.Parameters.AddWithValue("Address1", customersRow[4]);
                cmd.Parameters.AddWithValue("Address2", customersRow[5]);
                cmd.Parameters.AddWithValue("City", customersRow[6]);
                cmd.Parameters.AddWithValue("Phone", customersRow[7]);
                cmd.Parameters.AddWithValue("DateInSystem", customersRow[8]);

                cmd.ExecuteNonQuery();
            }
            customersRow.AcceptChanges();
        }

        public static void DeleteCustomers(DataRow customersRow)
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=ShopDB;Integrated Security=True";

            StringBuilder builder = new StringBuilder();

            string commandString = "DELETE Customers " +
                                   "WHERE CustomerNo = @CustomerNo";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(commandString, connection);
                cmd.Parameters.AddWithValue("CustomerNo", customersRow[0, DataRowVersion.Original]);

                cmd.ExecuteNonQuery();
            }
        }

        public static void Update(DataTable customers)
        {
            foreach (DataRow customer in customers.Rows)
            {
                if (customer.RowState == DataRowState.Deleted)
                    DeleteCustomers(customer);
                if (customer.RowState == DataRowState.Added)
                    InsertCustomers(customer);
                if (customer.RowState == DataRowState.Modified)
                    ChangeCustomers(customer);
            }
            customers.AcceptChanges();
        }
    }
}
