using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Updates
{
    static class CustomersUpdates
    {
        private static void DeleteCustomers(DataRow customersRow)
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

        public static void DeleteCustomers(DataTable customers)
        {
            foreach (DataRow row in customers.Rows)
            {
                if (row.RowState == DataRowState.Deleted)
                    DeleteCustomers(row);
            }
            customers.AcceptChanges();
        }
    }
}
