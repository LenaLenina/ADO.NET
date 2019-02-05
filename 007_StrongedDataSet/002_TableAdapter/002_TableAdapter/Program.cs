using System;
using System.Data;
using System.Data.SqlClient;

// Использование метода GetData адаптеры таблицы для создания ссылки на заполненную данными таблицу

namespace TableAdaptersWork
{
    class Program
    {
        static void Main(string[] args)
        {
            var customersTableAdapter = new ShopDBTableAdapters.CustomersTableAdapter();
            ShopDB.CustomersDataTable customers = customersTableAdapter.GetData();

            foreach (DataRow customersRow in customers.Rows)
            {
                foreach (DataColumn customersColumn in customers.Columns)
                    Console.WriteLine("{0}: {1}", customersColumn.ColumnName, customersRow[customersColumn]);

                Console.WriteLine();
            }

        }
    }
}
