using System;
using System.Data.SqlClient;
using System.Data;

// Использование объекта DataAdapter

namespace DataAdapter
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionStr = @"Data Source=.\SQLEXPRESS;Initial Catalog=ShopDB;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionStr);
            SqlCommand cmd = new SqlCommand("SELECT * FROM Customers", connection);

            DataTable customers = new DataTable("Customers");

            SqlDataAdapter adapter = new SqlDataAdapter(cmd); // одна из перегрузок конструктора DataAdapter принимает объект Command
            //SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Customers", connection);

            adapter.Fill(customers); // метод Fill объекта DataAdapter позволяет заполнить таблицу данными
            
            foreach (DataRow row in customers.Rows)
            {
                foreach (DataColumn column in customers.Columns)
                    Console.WriteLine("{0}: {1}", column.ColumnName, row[column]);

                Console.WriteLine();
            }
        }
    }
}
