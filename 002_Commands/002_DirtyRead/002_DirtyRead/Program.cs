using System;
using System.Data;
using System.Data.SqlClient;

namespace DirtyRead
{
    class Program
    {
        static void Main(string[] args)
        {
            string conStr = @" Initial Catalog=ShopDB; Data Source=.\SQLEXPRESS;  Integrated Security=True;"; // создание строки подключения

            SqlConnection connection = new SqlConnection(conStr);

            SqlCommand cmd = new SqlCommand("SELECT LName, FName, Phone FROM Customers", connection);

            Console.WriteLine("Step 2. Press any key to read Customers");
            Console.ReadKey();

            connection.Open();
            cmd.Transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine("{0} {1}: {2}", reader[0], reader[1], reader[2]);
            }

            connection.Close();
        }
    }
}
