using System;
using System.Data;
using System.Data.SqlClient;

// Метод SetAdded изменяет значение свойства RowState объекта DataRow на Added.
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

            Console.WriteLine("Before call SetAdded() - "+table.Rows[0].RowState);

            table.Rows[0].SetAdded();

            Console.WriteLine("After call SetAdded() - " + table.Rows[0].RowState);
        }
    }
}
