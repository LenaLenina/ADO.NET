using System;
using System.Data;
using System.Data.SqlClient;

// Свойство AllowDBNull объекта DataColumn возвращает или задает значение, 
// указывающее на допустимость нулевых значений в этом столбце для строк, принадлежащих таблице.

namespace CBS.ADO_NET.ColumnProperties
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable table = new DataTable();

            DataColumn column = table.Columns.Add("AllowDBNullColumn", typeof(int));
            column.AllowDBNull = false;

            DataRow newRow = table.NewRow();

            newRow[0] = DBNull.Value;

            table.Rows.Add(newRow); //ошибка времени выполнения

            Console.WriteLine(table.Rows[0][0]);
        }
    }
}
