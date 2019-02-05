using System;
using System.Data;

// Просмотр данных строки, подготовленной к удалению

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

            table.Rows[0].Delete();

            try
            {
                Console.WriteLine(table.Rows[0][0]); // Ошибка, потому как строка подготовлена к удалению
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            Console.WriteLine();
            Console.WriteLine(table.Rows[0][0, DataRowVersion.Original]);
        }
    }
}
