using System;
using System.Data.SqlClient;

// Работа со значениями NULL базы данных

namespace CBS.ADO_NET.DBNullValue
{
    class Program
    {
        static void Main(string[] args)
        {
            string conStr = @"Data Source=.\SQLEXPRESS; Initial Catalog=ShopDB; Integrated Security=True;"; // создание строки подключения

            SqlConnection connection = new SqlConnection(conStr); // создание подключения
            connection.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Customers;", connection);  // создание пакета запросов 

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine("Name: "+reader.GetString(2) + " " + reader.GetString(1) + " " + reader.GetString(3));

                //if (reader[5] == DBNull.Value) //ошибка времени выполнения.  
                if (reader.IsDBNull(5)) // метод IsDbNull позволяет проверить наличие данных в указанном поле источника данных 
                    Console.WriteLine("Address Line 2: " + "No Data");
                else
                    Console.WriteLine("Address Line 2: " + reader[5]);

                Console.WriteLine();
            }
        }
    }
}
