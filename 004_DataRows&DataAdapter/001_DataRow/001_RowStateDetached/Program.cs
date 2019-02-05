using System;
using System.Data;

// свойство RowState объекта DataRow

namespace RowStateDetached
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable table = new DataTable();

            table.Columns.Add(new DataColumn("Column1"));

            DataRow row = table.NewRow();

            row[0] = "SomeValue";
            Console.WriteLine(row.RowState); // Detached

            table.Rows.Add(row);
            Console.WriteLine(row.RowState); // Added

            table.AcceptChanges();
            //table.RejectChanges();
            Console.WriteLine(row.RowState); // Unchenged
        }
    }
}
