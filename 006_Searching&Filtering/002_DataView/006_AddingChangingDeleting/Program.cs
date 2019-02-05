using System;
using System.Data;

// Удаление, добавление и редактирование строк с помощью DataView

namespace AddingChangingDeleting
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable table = new DataTable();

            table.Columns.Add("Column1", typeof(int));
            table.Columns.Add("Column2");

            table.LoadDataRow(new object[]{1, "one"}, true);
            table.LoadDataRow(new object[] { 2, "two" }, true);
            table.LoadDataRow(new object[] { 3, "three" }, true);
            table.LoadDataRow(new object[] { 4, "four" }, true);

            DataView view = new DataView(table, "Column1 > 3", "Column1 desc", DataViewRowState.CurrentRows);

            var viewRow = view.AddNew();

            viewRow.BeginEdit();
            viewRow[0] = 5;
            viewRow[1] = "five";
            viewRow.EndEdit();

            foreach (DataRow tableRow in table.Rows)
            {
                foreach (DataColumn tableColumn in table.Columns)
                    Console.WriteLine("{0}: {1}", tableColumn.ColumnName, tableRow[tableColumn]);

                Console.WriteLine();
            }

            Console.WriteLine(new string('-', 20));

            viewRow.BeginEdit();
            viewRow["Column2"] = "Changed Value";
            viewRow.EndEdit();

            foreach (DataRow tableRow in table.Rows)
            {
                foreach (DataColumn tableColumn in table.Columns)
                    Console.WriteLine("{0}: {1}", tableColumn.ColumnName, tableRow[tableColumn]);

                Console.WriteLine();
            }

            viewRow.BeginEdit();
            viewRow.Delete();
            viewRow.EndEdit();

            Console.WriteLine(new string('-', 20));

            foreach (DataRow tableRow in table.Rows)
            {
                foreach (DataColumn tableColumn in table.Columns)
                    Console.WriteLine("{0}: {1}", tableColumn.ColumnName, tableRow[tableColumn]);

                Console.WriteLine();
            }
        }
    }
}
