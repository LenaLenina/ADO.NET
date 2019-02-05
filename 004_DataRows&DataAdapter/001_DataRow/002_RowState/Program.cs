using System;
using System.Data;
using System.Data.SqlClient;

// Значение Unchanged свойства RowState строки говорит о том, что строка не была изменена с момента последнего вызова AcceptChanges.


namespace RowState
{
    class Program
    {
        private static void LoadData(string commandString, string connectionString, DataTable table)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(commandString, connection);

                SqlDataReader reader = cmd.ExecuteReader();

                table.Load(reader); // метод Load при добавлении строк устанавливает им состояние Unchanged

                reader.Close();
            }
        }

        private static void SimpleLoadData(string commandString, string connectionString, DataTable table)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(commandString, connection);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var newRow = table.NewRow();

                    for (int i = 0; i < reader.FieldCount; i++)
                        newRow[i] = reader[i];

                    table.Rows.Add(newRow); 
                }
                reader.Close();
            }
        }

        static void Main(string[] args)
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=ShopDB;Integrated Security=True";
            string commandString = "SELECT * FROM Customers";

            DataTable customers = new DataTable();

            LoadData(commandString, connectionString, customers);

            for (int i = 0; i < customers.Rows.Count; i++)
                Console.WriteLine("Row {0}, RowState: {1}", i, customers.Rows[i].RowState);

            Console.WriteLine(new string('-', 20));
            customers.Clear();

            SimpleLoadData(commandString, connectionString, customers);

            for (int i = 0; i < customers.Rows.Count; i++)
                Console.WriteLine("Row {0}, RowState: {1}", i, customers.Rows[i].RowState);
        }
    }
}
