using System;
using System.Data.Common;
using System.Data.SqlClient;

// выполнение пакета операторов SQL с помощъю одного объекта SqlCommand

namespace CBS.ADO_NET.PackageCommands
{
    class Program
    {

        public static void WriteReaderData(DbDataReader reader)
        {
            while (reader.Read())                       // вывод данных возвращаемых вторым запросом 
            {
                for (int i = 0; i < reader.FieldCount; i++)
                    Console.WriteLine(reader.GetName(i)+": "+reader[i]);
                Console.WriteLine(new string('_', 20));
            }
        }

        static void Main(string[] args)
        {
            string conStr = @"Data Source=.\SQLEXPRESS; Initial Catalog=ShopDB; Integrated Security=True;"; // создание строки подключения

            SqlConnection connection = new SqlConnection(conStr); // создание подключения
            connection.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Customers WHERE CustomerNo = 1; SELECT * FROM Employees WHERE EmployeeID = 1;", connection);  // создание пакета запросов 

            SqlDataReader reader = cmd.ExecuteReader();

            Console.WriteLine("press any key to see data from Customers");
            Console.ReadKey();

            WriteReaderData(reader);  // вывод на экран данных

            Console.WriteLine("press any key to see data from Employees");
            Console.ReadKey();

            reader.NextResult();      // переход к следующему запросу     

            WriteReaderData(reader);  // вывод данных на экран

            connection.Close();
            reader.Close();           // не забывайте закрывать объект reader
            Console.ReadKey();
        }
    }
}
