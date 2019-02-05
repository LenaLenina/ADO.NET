using System;
using System.Data;
using System.Data.SqlClient;

// Получение значения автоинкремента с помощью хранимой процедуры

namespace IdenitytProcedure
{
    class Program
    {
        static string conStr = @"Data Source=.\SQLEXPRESS; Initial Catalog=ShopDB; Integrated Security=True;"; // создание строки подключения

        static int InsertCustomer()
        {
            SqlConnection connection = new SqlConnection(conStr);

            SqlCommand cmd = new SqlCommand("IdentityProcedure", connection) { CommandType = System.Data.CommandType.StoredProcedure };
            SqlParameter parameter = cmd.Parameters.Add(new SqlParameter());
            parameter.Direction = System.Data.ParameterDirection.ReturnValue; // после выполнения комманды parameter будет содержать возвращаемое значение хранимой процедуры 

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();

            Console.WriteLine("New customer with CustomerNo {0} was added", parameter.Value);
            return (int)parameter.Value;
        }


        static void DeleteCustomerByID(int customerNo)
        {
            SqlConnection connection = new SqlConnection(conStr);

            SqlCommand cmd = new SqlCommand("DELETE CUstomers WHERE CustomerNo = @CustomerNo", connection);
           
            SqlParameter parameter = cmd.Parameters.Add(new SqlParameter("CustomerNo", SqlDbType.Int));
            parameter.Direction = System.Data.ParameterDirection.Input;
            parameter.Value = customerNo;

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();

            Console.WriteLine("Customer with CustomerNo {0} was deleted", parameter.Value);
        }

        static void Main(string[] args)
        {
            // код хранимой процедуры 
            //  CREATE PROCEDURE IdentityProcedure 
            //  AS
            //  BEGIN
            //      INSERT Customers
            //      VALUES
            //      ('TEST','TEST', 'TEST', 'TEST', 'TEST', 'TEST', 'TEST', GETDATE())
            //      RETURN @@IDENTITY -- процедура возвращает значение автоинкремента добавленной строки
            //  END
            //  GO

            int customerNo = InsertCustomer(); // Добавление нового клиента в базу данных

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            DeleteCustomerByID(customerNo);    // Удаление добавленного клиента
        }
    }
}
