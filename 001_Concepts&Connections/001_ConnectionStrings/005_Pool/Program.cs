using System;
using System.Data.SqlClient;

    // Технология connection pooling позволяет уменьшить затраты на открытие и закрытие соединения

namespace CBS.ADO_NET.Pooling
{
    class Program
    {
        static void Main(string[] args)
        {
            string conStr = @"Data Source=.\SQLEXPRESS;Initial Catalog=ShopDB; Integrated Security=true; Pooling = false"; // включение или отключение пула для этого подключения

            DateTime start = DateTime.Now; 

            for (int i = 0; i < 1000; i++)
            {
                SqlConnection connection = new SqlConnection(conStr);
                connection.Open();    // при включенном пуле физическое соединение не создается, а берется из пула соединений
                connection.Close();   // при включенном пуле физическое соединение не разрывается, а помещается в пул
            }

            TimeSpan stop = DateTime.Now - start;

            Console.WriteLine(stop.TotalSeconds);
        }
    }
}
