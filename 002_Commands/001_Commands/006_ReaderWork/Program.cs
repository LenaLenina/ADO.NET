using System;
using System.Data.SqlClient;

// получение данных объекта DataReader с помощью индексатора

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

            // метод ExecuteReader возвращает новый объект SqlDataReader
            using ( SqlDataReader reader = cmd.ExecuteReader())
            {
                // с помощью объекта SqldataReder можно просматривать резельтаты запроса строка за строкой
                // метод Read() возвращает значение true или false в зависимости от того, имеется ли следующая строка, которую можно посмотреть
                // так же метод Read при каждом его вызове перемещается к следующей строке набора строк, пришедших тот сервера
                while (reader.Read())
                {
                    Console.WriteLine(reader[0]);                           // вывод на экран ID клиента испльзуя перегрузку оператора с целочисленным индексом          
                    Console.WriteLine(                                      // вывод на экран ФИО клиента испльзуя перегрузку оператора со строковым индексом  
                        reader["LName"] + " " +
                        reader["Fname"] + " " +
                        reader["MName"]
                        );
                    Console.WriteLine(reader[7]);                           // вывод на экран номера телефона клиента 
                    Console.WriteLine("{0:D}", reader[8]);                  // вывод на экран поля DataInSystem клиента        
                    //Console.WriteLine(reader.GetFieldValue<DateTime>(8));

                    Console.WriteLine(new string('_', 20));
                }
            } // при выходе из блока using redader будет закрываться автоматически
            connection.Close();
        }
    }
}
