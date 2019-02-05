using System;
using System.Data;
using System.Data.SqlClient;

// Работа со строками stroged DataSet

namespace GetChanges
{
    class Program
    {
        static void Main(string[] args)
        {
            ShopDB shopDB = new ShopDB();

            // создание строки для таблицы Customers
            ShopDB.CustomersRow customersRow = shopDB.Customers.NewCustomersRow(); 

            // Для заполнения полей строки используются строготипизированные свойства 
            customersRow.FName = "Алексей";
            customersRow.LName = "Петров";
            customersRow.MName = "Николаевич";
            customersRow.Address1 = "Лужная 7";
            customersRow.Address2 = null;
            customersRow.City = "Киев";
            customersRow.Phone = "(096)4578596";
            customersRow.DateInSystem = new DateTime(2009, 09, 18);

            // добавление созданной строки в коллекцию строк таблицы
            shopDB.Customers.Rows.Add(customersRow);

            // еще один способ добавления строки в соллекцию строк таблицы
            shopDB.Customers.AddCustomersRow("Николай", "Александров", "Анатольевич", "Московская 15", null, "Чернигов", "(063)0215478", new DateTime(2008, 05,15));

            foreach (DataRow row in shopDB.Customers.Rows)
            {
                foreach (DataColumn column in shopDB.Customers.Columns)
                    Console.WriteLine("{0}: {1}", column.ColumnName, row[column]);

                Console.WriteLine();
            }
        }
    }
}
