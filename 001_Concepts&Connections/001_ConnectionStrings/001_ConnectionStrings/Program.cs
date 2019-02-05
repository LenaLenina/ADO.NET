using System;
using System.Data.SqlClient; // в этом пространстве имен находится поставщик данных для MS SQLServer

namespace CBS.ADO_NET.ConnectionStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string conStr = @"Data Source=.\SQLEXPRESS;Initial Catalog=ShopDB; Integrated Security=True";               //строка подключения
            // string conStr = @"Data Source=(local)\SQLEXPRESS;Initial Catalog=ShopDB; Integrated Security=True"; 
            // string conStr = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=ShopDB; Integrated Security=True"; 

            // Следую инструкциям строки подключения следует найти на локальном компьютере экземпляр SQL Server  с именем SQLEXPRESS, 
            // поискать каталог ShopDB и попытаться получить доступ к источнику данных через доверительное подключение, 
            // используя для этого вашу учетную запись Microsoft Windows

            SqlConnection connection = new SqlConnection(conStr);
            
            try
            {
                connection.Open(); // открытие физического подключения к источнику данных 
                Console.WriteLine(connection.State);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close(); //закрытие физического соединения с источником данных
                Console.WriteLine(connection.State);
            }
        }
    }
}
