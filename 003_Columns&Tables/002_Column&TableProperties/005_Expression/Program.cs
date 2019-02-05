using System;
using System.Data;

// создание столбца, основанного на выражении

namespace Expression
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable multiplicationTable = new DataTable();

            DataColumn factor1 = new DataColumn("Factor 1", typeof(int));
            DataColumn factor2 = new DataColumn("Factor 2", typeof(int));
            DataColumn multiplication = new DataColumn("Multiplication", typeof(int));

            multiplication.Expression = "[Factor 1] * [factor 2]"; // свойство Expression объекта DataColumn задает выражение для расчета значения для ячейки строки

            multiplicationTable.Columns.AddRange(new DataColumn[]{factor1, factor2, multiplication});

            for (int i = 1; i < 10; i++)
                for (int j = 1; j < 10; j++)
                    multiplicationTable.LoadDataRow(new object[] { i, j }, true);


            foreach (DataRow row in multiplicationTable.Rows)
            {
                    Console.WriteLine("{0} * {1} = {2}", row[0], row[1], row[2]);
            }
        }
    }
}
