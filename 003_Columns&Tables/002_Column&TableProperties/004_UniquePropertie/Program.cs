using System;
using System.Data;

// свойство Unique объекта DataColumn возвращает или задает значение, показывающее, должны ли значения в каждой строке столбца быть уникальными.


namespace CBS.ADO_NET.ColumnProperties
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable table = new DataTable();

            DataColumn column = table.Columns.Add("UniqueColumn", typeof(string));
            column.Unique = true;

            DataRow newRow = table.NewRow();
            newRow[0] = "NonUniqueValue";
            table.Rows.Add(newRow);

            newRow = table.NewRow();
            newRow[0] = "NonUniqueValue";
            table.Rows.Add(newRow); // ошибка времени выполнения при нарушении ограничения Unique

            Console.WriteLine(table.Rows[0][0]);
            Console.WriteLine(table.Rows[1][0]);
        }
    }
}
