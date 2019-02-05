using System;
using System.Data;
using System.Data.SqlClient;

namespace ConnectionGetSchema
{
    class Program
    {
        static void Main(string[] args)
        {
            string conStr = @"Data Source=.\SQLEXPRESS; Initial Catalog=ShopDB; Integrated Security=True;"; // создание строки подключения

            SqlConnection connection = new SqlConnection(conStr);
            connection.Open();

        }
    }
}
