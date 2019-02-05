using System;
using System.Data.SqlClient;

// использование выходных параметров в параметризированных запросах

namespace CBS.ADO_NET.ParametrizedCommands
{
    class Program
    {
        static void Main(string[] args)
        {
            string conStr = @"Data Source=.\SQLEXPRESS; Initial Catalog=ShopDB; Integrated Security=True;"; // создание строки подключения
            SqlConnection connection = new SqlConnection(conStr);

            SqlCommand cmd = new SqlCommand("SET @Parameter = 2;", connection);

            SqlParameter parameter = cmd.Parameters.Add(new SqlParameter("Parameter", System.Data.SqlDbType.Int));
            parameter.Direction = System.Data.ParameterDirection.Output; // указание направления параметра

            connection.Open();

            cmd.ExecuteNonQuery();

            Console.WriteLine("Parameter value: " + parameter.Value); // вывод на экран значения параметра после выполнения запроса

            connection.Close();
        }
    }
}
