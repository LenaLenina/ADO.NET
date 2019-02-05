using System;
using System.Data;

// Применение перечисления DataRowVersion

namespace RowVersion
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Column1");

            table.LoadDataRow(new object[] { "one" }, true);
            table.LoadDataRow(new object[] { "two" }, true);
            table.LoadDataRow(new object[] { "three" }, true);


            for (int i = 0; i < table.Rows.Count; i++)
                table.Rows[i][0] = "ChangedValue";

            foreach (DataRow row in table.Rows)
            {
                Console.WriteLine("Column1 current value: " + row[0, DataRowVersion.Current]); // будут выведены текущие значения строк
                Console.WriteLine("Column1 original value: " + row[0, DataRowVersion.Original]); // будут выведены оригинальные значения строк
                Console.WriteLine("RowState: " + row.RowState);
                Console.WriteLine();
            }
        }
    }
}
