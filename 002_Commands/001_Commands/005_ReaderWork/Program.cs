using System;
using System.Data.SqlClient;

// получение данных объекта DataReader с помощью строготипизированных средств доступа

namespace CBS.ADO_NET.ExecuteTableCommands
{
    class Program
    {
        static void Main(string[] args)
        {
            string conStr = @"Data Source=.\SQLEXPRESS; Initial Catalog=ShopDB; Integrated Security=True;"; // создание строки подключения

            SqlConnection connection = new SqlConnection(conStr); // создание подключения

            SqlCommand cmd = new SqlCommand("SELECT * FROM Customers", connection); // построение команды, возвращающей данные в табличном представлениии

            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader(); // метод ExecuteReader возвращает 

            // с помощью объекта SqldataReder можно просматривать резельтаты запроса строка за строкой
            // метод Read() возвращает значение true или false в зависимости от того, имеется ли следующая строка, которую можно посмотреть
            // так же метод Read при каждом его вызове перемещается к следующей строке набора строк, пришедших тот сервера
            while (reader.Read())
            {
                Console.WriteLine(reader.GetFieldValue<int>(0));        // вывод на экран ID клиента испльзуя метод GetFieldValue          
                Console.WriteLine(                                      // вывод на экран ФИО клиента испльзуя метод GetString
                    reader.GetString(2)+" "+
                    reader.GetString(1)+" "+
                    reader.GetString(3)
                    );
                Console.WriteLine(reader.GetFieldValue<string>(7));     // вывод на экран номера телефона клиента 
                Console.WriteLine("{0:D}",reader.GetDateTime(8));       // вывод на экран поля DataInSystem клиента        
                //Console.WriteLine(reader.GetFieldValue<DateTime>(8));
                
                Console.WriteLine(new string('_',20));
            }
            reader.Close();
            connection.Close();
        }
    }
}
