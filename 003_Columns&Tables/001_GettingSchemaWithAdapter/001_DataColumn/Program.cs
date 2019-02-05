using System;
using System.Data;
using System.Data.SqlClient;

// Создание экземпляров DataColumn и добавление их в коллекцию столбцов объекта DataTable

namespace DataSetBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable table = new DataTable("MyFirstTable");

            DataColumn firstColumn = new DataColumn("First Column", typeof(int));
            DataColumn secondColumn = new DataColumn("Second column", typeof(string));

            DataColumnCollection columnCollection = table.Columns;
            columnCollection.AddRange(new DataColumn[]{firstColumn, secondColumn});

            foreach (DataColumn column in table.Columns)
                Console.WriteLine("{0}: {1};", column.ColumnName, column.DataType);
        }
    }
}
