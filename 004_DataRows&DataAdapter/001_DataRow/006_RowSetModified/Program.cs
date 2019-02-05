using System;
using System.Data;
using System.Data.SqlClient;

// Метод SetModified изменяет значение свойства Rowstate объекта DataRow на Modified.
// Если метод SetAdded вызывается для строки, котороя имеет состояние отличное от Unchanged или Added генерируется исключительная ситуация

namespace RowState
{
    class Program
    {
        
        static void Main(string[] args)
        {
            DataTable table = new DataTable();

            table.Columns.Add("Column1");

            table.LoadDataRow(new[] { "Value" }, true);

            Console.WriteLine("Before call SetModified() - " + table.Rows[0].RowState);

            table.Rows[0].SetModified();

            Console.WriteLine("After call SetModified() - " + table.Rows[0].RowState);
        }
    }
}
