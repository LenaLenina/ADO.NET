using System;
using System.Data.SqlClient;

// выполнение команд, возвращающих данные в табличном представлении

namespace CBS.ADO_NET.ExecuteTableCommands
{
    class Program
    {
        static void Main(string[] args)
        {
            string conStr = @"Data Source=.\SQLEXPRESS; Initial Catalog=ShopDB; Integrated Security=True;"; // создание строки подключения

            SqlConnection connection = new SqlConnection(conStr); // создание подключения
            connection.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Customers", connection); // построение команды, возвращающей данные в табличном представлениии

            SqlDataReader reader = cmd.ExecuteReader(); 

            // с помощью объекта SqldataReder можно просматривать резельтаты запроса строка за строкой
            // метод Read() возвращает значение true или false в зависимости от того, достигнут ли конец пакета строк, пришедших от сервера
            // так же метод Read при каждом его вызове перемещается к следующей строке пакета, пришедшего от сервера
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.WriteLine(reader.GetName(i) + ": " + reader[i]);
                }
                Console.WriteLine(new string('_', 20));
            }
            reader.Close();
            connection.Close();
        }
    }
}
