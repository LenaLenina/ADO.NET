using System;
using System.Data.SqlClient;

namespace _006_Pooling
{
    class Program
    {
        static void Main(string[] args)
        {
            string conStr = @"Data Source=.\SQLEXPRESS;Initial Catalog=ShopDB; Integrated Security=True; Pooling = true;"; // включение или отключение пула для этого подключения

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
