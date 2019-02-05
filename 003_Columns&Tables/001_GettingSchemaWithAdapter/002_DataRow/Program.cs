using System;
using System.Data;
using System.Data.SqlClient;

// Создание строки для таблицы и добавление ее в коллекцию строк объекта DataTable

namespace BasicsDataRow
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable table = new DataTable();

            table.Columns.Add(new DataColumn("Column1", typeof(int)));
            table.Columns.Add(new DataColumn("Column2"));

            DataRow newRow = table.NewRow();

            newRow["Column1"] = 1; // индексатор объекта DataRow в качастве строкового индекса принимает имя поля в строке к которому нужно обратиться
            //newRow[0] = 1;

            newRow["COlumn2"] = "One";
            //newRow[1] = "One";          // индексатор объекта DataRow в качастве целочисленного индекса принимает индекс поля в строке к которому нужно обратиться

            Console.WriteLine("table.Rows.Count: " + table.Rows.Count); // выведется 0

            table.Rows.Add(newRow); // строка становится строкой таблицы при добавлении её в коллекцию Rows таблицы

            Console.WriteLine("table.Rows.Count: " + table.Rows.Count); // выведется 1

            Console.WriteLine();

            foreach (DataRow row in table.Rows)
            {
                foreach (DataColumn column in table.Columns)
                    Console.WriteLine("{0}: {1}", column.ColumnName, row[column]);
            }
        }
    }
}
