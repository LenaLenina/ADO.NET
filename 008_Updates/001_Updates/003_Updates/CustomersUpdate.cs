using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Updates
{
    static class CustomersUpdates
    {
        private static void ChangeCustomers(DataRow customersRow)
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

        public static void ChangeCustomers(DataTable customers)
        {
            foreach (DataRow row in customers.Rows)
            {
                if (row.RowState == DataRowState.Modified)
                    ChangeCustomers(row);
            }
        }
    }
}
