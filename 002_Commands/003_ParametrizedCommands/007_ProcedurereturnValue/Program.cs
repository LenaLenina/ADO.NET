using System;
using System.Data.SqlClient;

// выполнение процедура, возвращающей значение

namespace CBS.ADO_NET.ParametrizedCommands
{
    class Program
    {
        static void Main(string[] args)
        {
            // код хранимой процедуры CREATE PROCEDURE ProcedureReturnValue
                                //    AS
                                //    BEGIN
                                //    return 1;
                                //    END

            string conStr = @"Data Source=.\SQLEXPRESS; Initial Catalog=ShopDB; Integrated Security=True;"; // создание строки подключения
            SqlConnection connection = new SqlConnection(conStr);

            SqlCommand cmd = new SqlCommand("ProcedureReturnValue", connection) { CommandType = System.Data.CommandType.StoredProcedure };
            SqlParameter parameter = cmd.Parameters.Add(new SqlParameter()); 
            parameter.Direction = System.Data.ParameterDirection.ReturnValue; // после выполнения комманды parameter будет содержать возвращаемое значение хранимой процедуры 
           
            connection.Open();

            cmd.ExecuteNonQuery(); 

            Console.WriteLine(parameter.Value);
        }
    }
}
