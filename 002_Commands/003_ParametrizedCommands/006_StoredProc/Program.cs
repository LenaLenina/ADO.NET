using System;
using System.Data.SqlClient;

// выполнение хранимой процедуры, принимающей параметры

namespace CBS.ADO_NET.ParametrizedCommands
{
    class Program
    {
        static void Main(string[] args)
        {
            // код хранимой процедуры selectEmp: CREATE proc dbo.proc_p1  @EmployeeID nvarchar(50) 
                                             //    AS 
                                             //    SELECT * from dbo.Employees  
                                             //    WHERE EmployeeID = @EmployeeID  

            string conStr = @"Data Source=.\SQLEXPRESS; Initial Catalog=ShopDB; Integrated Security=True;"; // создание строки подключения
            SqlConnection connection = new SqlConnection(conStr);

            Console.WriteLine("Enter employeeID");
            int employeeID = int.Parse(Console.ReadLine()); // получение данных от пользователя

            SqlCommand cmd = new SqlCommand("proc_p1", connection) { CommandType = System.Data.CommandType.StoredProcedure }; // создание команды, вызывающей хранимую процедуру

            cmd.Parameters.AddWithValue("@EmployeeID", employeeID); // добавление одного параметра

            connection.Open();

            SqlDataReader reader = cmd.ExecuteReader(); // выполнение команды

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
 