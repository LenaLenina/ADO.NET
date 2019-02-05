using System;
using System.Data.SqlClient;
using System.Data;

// поиск данных в таблице с помощью метода Find объекта DataRowCollection

namespace SearchingAndFiltering
{
    class Program
    {
        static void Main(string[] args)
        {
            DataSet ds = new DataSet();

            string connecionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=ShopDB;Integrated Security=True";
            string commandString = "SELECT * FROM Customers";

            SqlDataAdapter adapter = new SqlDataAdapter(commandString, connecionString);

            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            adapter.Fill(ds);

            DataTable customers = ds.Tables[0];

            DataRow customersRow = customers.Rows.Find(2);

            foreach (DataColumn customersColumn in customers.Columns)
                Console.WriteLine(customersColumn.ColumnName+" "+customersRow[customersColumn]);
        }
    }
}
