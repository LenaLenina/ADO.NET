using System;
using System.Data.SqlClient;

// Создание SqlCommand

namespace CBS.ADO_NET.CreateCommand
{
    class Program
    {
        static void Main(string[] args)
        {
            string conStr = @"Data Source=.\SQLEXPRESS; Initial Catalog=ShopDB; Integrated Security=True;"; // создание строки подключения
            SqlConnection connection = new SqlConnection(conStr);

            //**********Первый способ**************
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "Some T-SQL Command";

            //**********Второй способ**************
            cmd = connection.CreateCommand();
            cmd.CommandText = "Some T-SQL Command";

            //**********Третий способ**************
            cmd = new SqlCommand("Some T-SQL Command", connection);

        }
    }
}
