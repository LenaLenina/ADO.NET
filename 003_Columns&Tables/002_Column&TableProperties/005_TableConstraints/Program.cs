using System;
using System.Data;

// Класс UniqueConstraint предоставляет ограничение на набор столбцов, в которых все значения должны быть уникальными.
// Следует пользоваться этим ограничением в том случае, когда необходимо гарантировать уникальность 
// комбинаций значений различных полей таблицы 

namespace CBS.ADO_NET.TableConstraints
{
    static class TableExtentions
    {
          public static void AddRow(this DataTable table, string column1Val, string column2Val)
        {
            var newRow = table.NewRow();

            newRow[0] = column1Val;
            newRow[1] = column2Val;

            table.Rows.Add(newRow);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DataTable table = new DataTable();

            DataColumn column1 = table.Columns.Add("Column1", typeof(string));
            DataColumn column2 = table.Columns.Add("Column2", typeof(string));

            table.Constraints.Add("tableUniqueConstraint", new[] { column1, column2 }, false);

            table.AddRow("Unique", "Unique");
            table.AddRow("Unique", "Unique");
        }
    }
}
