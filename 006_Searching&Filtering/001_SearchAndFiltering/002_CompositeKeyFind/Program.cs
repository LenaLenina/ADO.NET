using System;
using System.Data.SqlClient;
using System.Data;

// поиск данных в таблице с помощью метода Find объекта DataRowCollection в таблице с составным ключом

namespace SearchingAndFiltering
{
    class Program
    {
        static void Main(string[] args)
        {
            DataSet ds = new DataSet();

            string connecionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=ShopDB;Integrated Security=True";
            string commandString = "SELECT * FROM OrderDetails";

            SqlDataAdapter adapter = new SqlDataAdapter(commandString, connecionString);

            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            adapter.Fill(ds);

            DataTable orderDetails = ds.Tables[0];

            DataRow customersRow = orderDetails.Rows.Find(new object[] { 1, 2 });

            foreach (DataColumn customersColumn in orderDetails.Columns)
                Console.WriteLine(customersColumn.ColumnName + " " + customersRow[customersColumn]);
        }
    }
}
