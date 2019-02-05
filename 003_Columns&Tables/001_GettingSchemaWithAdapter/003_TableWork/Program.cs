using System;
using System.Data;
using System.Data.SqlClient;

// создание методов, позволяющих создавать новую таблицу на основе данных, предоставляемых объектом DataReader

namespace TableWork
{
    class Program
    {
        // This method creates new DataTable with schema same to SqlDataReader 
        private static DataTable CreateSchemaFromReader(SqlDataReader reader, string tableName)
        {
            DataTable table = new DataTable(tableName);

            for (int i = 0; i < reader.FieldCount; i++)
                table.Columns.Add(new DataColumn(reader.GetName(i), reader.GetFieldType(i)));
          
            return table;
        }

        // This method write data to DataTable whith same schema as DataReader
        private static void WriteDataFromReader(DataTable table, SqlDataReader reader)
        {
            while (reader.Read())
            {
                DataRow row = table.NewRow();

                for (int i = 0; i < reader.FieldCount; i++)
                    row[i] = reader[i];

                table.Rows.Add(row);
            }
        }


        static void Main(string[] args)
        {
            string conStr = @"Data Source=.\SQLEXPRESS; Initial Catalog=ShopDB; Integrated Security=True;"; // создание строки подключения

            SqlConnection connection = new SqlConnection(conStr);
            connection.Open(); 

            SqlCommand cmd = new SqlCommand("SELECT * FROM Customers", connection);

            SqlDataReader reader = cmd.ExecuteReader();
            DataTable table = CreateSchemaFromReader(reader, "Customers"); // создание новой таблицы на основе схемы, предоставляемой DataReader

            foreach (DataColumn column in table.Columns)
                Console.WriteLine("{0}: {1}", column.ColumnName, column.DataType);

            WriteDataFromReader(table, reader); // запись данных  в таблицу с помощью DataReader
            Console.WriteLine();

            foreach (DataRow row in table.Rows)
            {
                foreach (DataColumn column in table.Columns)
                    Console.WriteLine("{0}: {1}", column.ColumnName, row[column]);
                
                Console.WriteLine();
            }

            reader.Close();
            connection.Close();
        }
    }
}
