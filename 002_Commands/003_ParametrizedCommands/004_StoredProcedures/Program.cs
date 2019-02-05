using System;
using System.Data.SqlClient;

// Вызов хранимой процедуры с использованием команды EXECUTE T-SQL

namespace CBS.ADO_NET.ParametrizedCommands
{
    class Program
    {
        static void Main(string[] args)
        {
            // код хранимой процедуры selectEmp:  CREATE proc dbo.selectEmp 
                                            //    as select * from dbo.Employees

            string conStr = @"Data Source=.\SQLEXPRESS; Initial Catalog=ShopDB; Integrated Security=True;"; // создание строки подключения
            SqlConnection connection = new SqlConnection(conStr);

            SqlCommand cmd = new SqlCommand("EXECUTE selectEmp", connection);  // создание команды, выполняющей хранимую процедуру selectEmp

            connection.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                    Console.WriteLine("{0}: {1}", reader.GetName(i), reader[i]);

                Console.WriteLine();
            }

            connection.Close();
        }
    }
}
