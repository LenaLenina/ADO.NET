using System;
using System.Data;

// Значение Deleted свойства RowState строки говорит о том, что cтрока была удалена с помощью метода Delete объекта DataRow.


namespace RowStateDeleted
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable table = new DataTable();

            table.Columns.Add(new DataColumn("Column1"));

            DataRow row = table.NewRow();

            Console.WriteLine("Table rows count: " + table.Rows.Count);
            Console.WriteLine("RowState: " + row.RowState);
            Console.WriteLine();

            row[0] = "SomeValue";
            table.Rows.Add(row);
            table.AcceptChanges();

            Console.WriteLine("Table rows count: " + table.Rows.Count);
            Console.WriteLine("RowState: " + row.RowState);
            Console.WriteLine();

            table.Rows[0].Delete(); // строка подготовлена к удалению. На самом деле она еще находится в коллекции строк объекта DataTable

            Console.WriteLine("Table rows count: " + table.Rows.Count);
            Console.WriteLine("RowState: " + row.RowState);
            Console.WriteLine();

            table.AcceptChanges(); // При вызове метода AcceptChanges строки подготовленные к удалению удаляются из коллекции строк таблицы
            //table.RejectChanges(); // Метод RejectChanges может анулировать все изменения, произведенные со строками относительно последнего вызова метода AcceptChanges

            Console.WriteLine("Table rows count: " + table.Rows.Count);
            Console.WriteLine("RowState: " + row.RowState);
        }
    }
}
