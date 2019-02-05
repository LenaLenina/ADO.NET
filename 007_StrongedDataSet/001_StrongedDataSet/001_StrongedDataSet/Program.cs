using System;
using System.Data;
using System.Data.SqlClient;

// Создание строготипизированного DataSet. Добавление строк в таблицы.

namespace GetChanges
{
    class Program
    {
        static void Main(string[] args)
        {
           ShopDB shopDB = new ShopDB(); // создание строготипизированного DataSet

           DataRow customersRow = shopDB.Customers.NewRow(); // Создание новой строки. Тип DataRow

           // заполнение полей строки данными 
           customersRow[0] = 1;
           customersRow[1] = "Алексей";
           customersRow[2] = "Петров";
           customersRow[3] = "Николаевич";
           customersRow[4] = "Лужная 7";
           customersRow[5] = DBNull.Value;
           customersRow[6] = "Киев";
           customersRow[7] = "(096)4578596";
           customersRow[8] = "2009/09/18";

           // добавление строки в коллекцию строк таблицы
           shopDB.Customers.Rows.Add(customersRow);

           // вывод данных на экран
           foreach (DataRow row in shopDB.Customers.Rows)
           {
               foreach (DataColumn column in shopDB.Customers.Columns)
                   Console.WriteLine("{0}: {1}",column.ColumnName,row[column]);
           }
        }
    }
}