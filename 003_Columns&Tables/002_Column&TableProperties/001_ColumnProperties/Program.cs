using System;
using System.Data;
using System.Data.SqlClient;

// Свойство Reaonly объекта DataColumn позволяет задать значение, указывающее на допустимость изменения столбца после добавления строки в таблицу.

namespace CBS.ADO_NET.ColumnProperties
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable table = new DataTable();

            DataColumn column = table.Columns.Add("ReadonlyColumn", typeof(string));
            column.ReadOnly = true; // столбец таблицы c именем ReadonlyColumn доступен только для чтения

            DataRow newRow = table.NewRow();

            newRow[0] = "ReadonlyValue";

            table.Rows.Add(newRow);
            
            Console.WriteLine(table.Rows[0][0]);

            table.Rows[0][0] = "NewValue"; // ОШИБКА времени выполнения
        }
    }
}
