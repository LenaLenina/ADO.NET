using System;
using System.Data;
using System.Data.SqlClient;

// Работа с адаптерами таблиц строго типизированного DataSet 

namespace TableAdaptersWork
{
    class Program
    {
        static void Main(string[] args)
        {
            ShopDB shopDB = new ShopDB();

            // Для каждой таблицы типизированного DataSet создается адаптер, который позволяет заполнить эту таблицу данными
            var customersTableAdapter = new ShopDBTableAdapters.CustomersTableAdapter();

            // Заполнение таблиц данными производится с помощью вызова метода Fill
            customersTableAdapter.Fill(shopDB.Customers);

            foreach (DataRow customersRow in shopDB.Customers.Rows)
            {
                foreach (DataColumn customersColumn in shopDB.Customers.Columns)
                    Console.WriteLine("{0}: {1}", customersColumn.ColumnName, customersRow[customersColumn]);
                
                Console.WriteLine();
            }

        }
    }
}
