using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

// Использование поставщика данных .NET OleDB

namespace OLEDB_Provider
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectToAccessDB();
            ConnectToExcelDB();
        }

        // Подключение к Microsoft Access 
        private static void ConnectToAccessDB()
        {
            var conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; Data Source= D:\ADO.NET\DATA\Access.mdb");

            try
            {
                conn.Open();
                Console.WriteLine("Connection to .mdb(AccessDB) file opened successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            finally
            {
                conn.Close();
                Console.WriteLine("Connection closed");
            }
        }

        // Подключение Microsoft Excel
        private static void ConnectToExcelDB()
        {
            var conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=D:\ADO.NET\DATA\Excel.xls; Extended Properties=""Excel 8.0""");

            try
            {
                conn.Open();
                Console.WriteLine("Connection to .xls(ExcelDB) file opened successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            finally
            {
                conn.Close();
                Console.WriteLine("Connection closed");
            }
        }

       
    }
}
