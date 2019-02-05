using System;
using System.Data;

// создание таблицы с помощью представления

namespace CreatingTableFromView
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable table = new DataTable();

            table.Columns.Add("Column1", typeof(int));
            table.Columns.Add("Column2");

            table.LoadDataRow(new object[] { 1, "one" }, true);
            table.LoadDataRow(new object[] { 2, "two" }, true);
            table.LoadDataRow(new object[] { 3, "three" }, true);
            table.LoadDataRow(new object[] { 3, "three" }, true);
            table.LoadDataRow(new object[] { 4, "four" }, true);

            DataView view = new DataView(table, "Column1 > 2", "Column1 desc", DataViewRowState.CurrentRows);

            DataTable tableFormView = view.ToTable(false, "Column2", "Column1");

            foreach (DataRow row in tableFormView.Rows)
            {
                foreach (DataColumn column in tableFormView.Columns )
                    Console.WriteLine("{0}: {1}", column.ColumnName, row[column]);

                Console.WriteLine();
            }
        }
    }
}