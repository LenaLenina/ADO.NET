using System;
using System.Data;
using System.Data.SqlClient;

// использование метода GetSchemaTable для получения информации о схеме таблицы к которой обращается объект DataReader


namespace SomeName
{
    class Program
    {
        static void Main(string[] args)
        {
            string conStr = @"Data Source=.\SQLEXPRESS; Initial Catalog=ShopDB; Integrated Security=True;"; // создание строки подключения

            SqlConnection connection = new SqlConnection(conStr);
            connection.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Customers", connection);

            SqlDataReader reader = cmd.ExecuteReader();

            DataTable schemaTable = reader.GetSchemaTable(); //получение информации о схеме таблицы Customers

            foreach (DataRow row in schemaTable.Rows) // вывод на экран информации, предоставляемой методом GetSchemaTable
            {
                foreach (DataColumn column in schemaTable.Columns)
                    Console.WriteLine("{0}: {1}", column.ColumnName, row[column]);

                Console.WriteLine();
            }


            DataTable customers = new DataTable("Customers");

            foreach (DataRow row in schemaTable.Rows)
            {
                var dataColumnToInsert = new DataColumn((string)row["ColumnName"], (Type)row["DataType"]);
                customers.Columns.Add(dataColumnToInsert); // добавление столбцов в таблицу customers
            }

            Console.WriteLine(new string('-', 20));
            foreach (DataColumn customersColumn in customers.Columns)
                Console.WriteLine("{0}: {1}", customersColumn.ColumnName, customersColumn.DataType);  // вывод имен и типов данных столбцов таблицы Customers

            reader.Close();
            connection.Close();
        }
    }
}
