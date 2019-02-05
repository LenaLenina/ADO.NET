using System;
using System.Data.SqlClient;

// Выполнение команд, возвращающих скалярные значения

namespace CBS.ADO_NET.ExecuteCommand
{
    class Program
    {
        static void Main(string[] args)
        {
            string conStr = @"Data Source=.\SQLEXPRESS; Initial Catalog=ShopDB; Integrated Security=True;"; // создание строки подключения
            SqlConnection connection = new SqlConnection(conStr);
            connection.Open(); // открытие подключения

            SqlCommand cmd = new SqlCommand("SELECT Phone FROM Customers WHERE CustomerNo = 1", connection); // создание команды, возвращающей скалярное значение

            string phoneNumber = (string)cmd.ExecuteScalar(); // выполнение команды

            Console.WriteLine(phoneNumber);
        }
    }
}
