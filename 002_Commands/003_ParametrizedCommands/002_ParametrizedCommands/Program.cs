using System;
using System.Data.SqlClient;

// создание и выполнение параметризированных запросов с использование коллекции Parameters объекта SqlCommand

namespace CBS.ADO_NET.ParametrizedCommands
{
    class Program
    {
        static void Main(string[] args)
        {
            var conStr = @"Data Source=.\SQLEXPRESS; Initial Catalog=ShopDB; Integrated Security=True;"; // создание строки подключения
           
            var commandStr = "SELECT * FROM Customers WHERE CustomerNo = @CustomerNo;"; // строка с запросом 

            Console.WriteLine("Enter customer ID");
            var customerNo = Console.ReadLine(); // получение ID клиента от пользователя

            SqlConnection connection = new SqlConnection(conStr); // создание подключения
            SqlCommand cmd = new SqlCommand(commandStr, connection); // создание команды

            cmd.Parameters.AddWithValue("CustomerNo", customerNo);   // добавление параметра в коллекцию параметров команды
            connection.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                    Console.WriteLine("{0}: {1}", reader.GetName(i), reader[i]);

                Console.WriteLine(new string('-',20));
            }

            reader.Close();
            connection.Close();
        }
    }
}
