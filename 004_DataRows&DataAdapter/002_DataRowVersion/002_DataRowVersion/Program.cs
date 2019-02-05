using System;
using System.Data;

// Proposed версия строки

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
            
            //-----------------------------------------------
           
            for (int i = 0; i < table.Rows.Count; i++)
            {
                table.Rows[i].BeginEdit();
                table.Rows[i][0] = "ChangedValue";
            }

            ShowDataAndMessage("Data after call BeginEdit()", table);

            for (int i = 0; i < table.Rows.Count; i++)
                table.Rows[i].EndEdit();

            ShowDataAndMessage("Data after call EndEdit()", table);

            table.AcceptChanges();

            ShowDataAndMessage("Data after call AcceptChanges()", table);
            
        }

        private static void ShowData(DataTable table)
        {
            foreach (DataRow row in table.Rows)
            {
                // версия Proposed строки доступна только при редактировании с помощью метода BeginEdit
                object proposedValue = row.HasVersion(DataRowVersion.Proposed) ? row[0, DataRowVersion.Proposed] : "no data"; 

                Console.WriteLine("Column2 current value: " + row[0, DataRowVersion.Current]);
                Console.WriteLine("Column2 original value: " + row[0, DataRowVersion.Original]);
                Console.WriteLine("Column2 proposed value: " + proposedValue);
                Console.WriteLine("RowState: " + row.RowState);
                Console.WriteLine();
            }
        }

        private static void ShowDataAndMessage(string message, DataTable table)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.Gray;

            ShowData(table);
            Console.ReadKey();
        }
    }
}
