using System;
using System.Data.SqlClient;

// Выполнение команд вставки и удаления

namespace CBS.ADO_NET.ExecuteCommand
{
    class Program
    {
        static void Main(string[] args)
        {
            string conStr = @"Data Source=.\SQLEXPRESS; Initial Catalog=ShopDB; Integrated Security=True;"; // создание строки подключения
            
            SqlConnection connection = new SqlConnection(conStr); // создание подключения
            connection.Open();

            // INSERT command

            SqlCommand insertCommand = connection.CreateCommand(); // создание команды на вставку данных
            insertCommand.CommandText = "INSERT Customers VALUES ('Alex', 'Petrov', 'Petrovich', 'Заворотная 7', NULL, 'Kiyv', '(063)8569584', '2010-01-01')";

            int rowAffected = insertCommand.ExecuteNonQuery(); // выполнение команды на вставку
            Console.WriteLine("INSERT command rows affected: "+rowAffected);


            // DELETE command

            SqlCommand deleteCommand = connection.CreateCommand(); // создание команды на удаление данных
            deleteCommand.CommandText = "DELETE Customers WHERE Phone = '(063)8569584'";

            rowAffected = deleteCommand.ExecuteNonQuery(); // выполнение команды на удаление
            Console.WriteLine("DELETE command rows affected: " + rowAffected);

            connection.Close();
        }


    }
}
