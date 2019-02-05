using System;
using System.Data.SqlClient;

// создание параметризированных заросов с помощью конкатенации строк 

namespace CBS.ADO_NET.ParametrizedCommands
{
    class Program
    {
        static void Main(string[] args)
        {
            string conStr = @"Data Source=.\SQLEXPRESS; Initial Catalog=ShopDB; Integrated Security=True;"; // создание строки подключения

            Console.WriteLine("Введите ID клиента");

            var customerNo = Console.ReadLine();

            // не используйте конкатенацию строк для запросов во избежание изменения структуры запроса пользователем
            string commandStr = string.Format("SELECT * FROM Customers WHERE CustomerNo = {0};", customerNo); // для создания параматризированного запроса используется метод string.Format

            using (SqlConnection connection = new SqlConnection(conStr)) // создание подключения
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(commandStr, connection);

                using (SqlDataReader reader = cmd.ExecuteReader()) // выполнение запроса и чтение результатов
                {
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                            Console.WriteLine("{0}: {1}", reader.GetName(i), reader[i]);
                        Console.WriteLine(new string('-', 20));
                    }
                }
            }
        }
    }
}
