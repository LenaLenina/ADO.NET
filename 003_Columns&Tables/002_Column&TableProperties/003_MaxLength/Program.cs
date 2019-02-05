using System;
using System.Data;

// Свойтсво MaxLength объекта DataColumn возвращает или задает максимальную длину текстового столбца.

namespace CBS.ADO_NET.ColumnProperties
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable table = new DataTable();

            DataColumn column = table.Columns.Add("MaxLengthConstraintColumn", typeof(string));
            column.MaxLength = 5;

            DataRow newRow = table.NewRow();

            newRow[0] = "Some value";

            table.Rows.Add(newRow); // ошибка времени выполнения

            Console.WriteLine(table.Rows[0][0]);
        }
    }
}
