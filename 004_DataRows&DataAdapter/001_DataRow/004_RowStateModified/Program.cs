using System;
using System.Data;
using System.Data.SqlClient;

//Значение Modified свойства RowState строки говорит о том, что cтрока была изменена и объект AcceptChanges не был вызван.

namespace RowState
{
    class Program
    {
       

        static void Main(string[] args)
        {
            DataTable table = new DataTable();

            table.Columns.Add("Column1");

            table.LoadDataRow(new[] { "Value" }, true);

            table.Rows[0][0] = "NewValue";

            Console.WriteLine("Before accept changes: "+table.Rows[0].RowState);

            table.AcceptChanges();

            Console.WriteLine("After accept changes: "+table.Rows[0].RowState);
        }
    }
}
