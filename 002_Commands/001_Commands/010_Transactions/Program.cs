using System;
using System.Data.SqlClient;
using System.Data;

// Создание транзакций для команд

namespace Transactions
{
    class Program
    {
        static void Main(string[] args)
        {
            string conStr = @"Data Source=.\SQLEXPRESS; Initial Catalog=ShopDB; Integrated Security=True;"; // создание строки подключения

            SqlConnection connection = new SqlConnection(conStr);

            SqlCommand cmd = new SqlCommand("UPDATE Customers SET Phone = 'TEST' WHERE CustomerNo = 1", connection);
            //cmd = new SqlCommand("UPDATE Customers SET Phone = '(052)1245789' WHERE CustomerNo = 1", connection);

            try
            {
                connection.Open();
               
                cmd.Transaction = connection.BeginTransaction();
                cmd.ExecuteNonQuery();

                throw new Exception();

                cmd.Transaction.Commit();

                Console.WriteLine("Transaction commited");
            }
            catch (Exception)
            {
                cmd.Transaction.Rollback();
                Console.WriteLine("Transaction rollback");
            }          
        }
    }
}
