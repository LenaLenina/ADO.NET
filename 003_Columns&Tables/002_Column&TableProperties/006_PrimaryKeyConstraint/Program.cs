using System;
using System.Data;

//PrimaryKey – особый вид ограничения на уникальность. Первичный ключ таблицы может быть только один

namespace CBS.ADO_NET.TableConstraints
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable table = new DataTable();

            DataColumn column1 = table.Columns.Add("Column1", typeof(string));
            DataColumn column2 = table.Columns.Add("Column2", typeof(string));

            table.Constraints.Add(new UniqueConstraint(column1, false));

            Console.WriteLine("is unique: " + table.Columns[0].Unique);
            Console.WriteLine("Primary key columns count: "+ table.PrimaryKey.Length);

            if (table.PrimaryKey.Length != 0)
                Console.WriteLine("Primary key column name: " + table.PrimaryKey[0].ColumnName);
            else
                Console.WriteLine("Primary key column name: No data");

        }
    }
}
