using System;
using System.Data.SqlClient;
using System.Data;

namespace EditingRow
{
    class Program
    {
   
        static void Main(string[] args)
        {
            DataTable table = new DataTable();

            table.Columns.Add("Column1");

            table.LoadDataRow(new[] { "Value" }, true);

            Console.WriteLine("Initial value: "+table.Rows[0][0]);

            table.Rows[0].BeginEdit();
            table.Rows[0][0] = "NewValue";

            Console.WriteLine("Purposed value: " + table.Rows[0][0]+ "\n");

            Console.WriteLine("Accept changes? Yes/No");
            var choice = Console.ReadLine();
            
            switch (choice)
            {
                case "Yes":
                    table.Rows[0].EndEdit();
                    break;
                case "No":
                    table.Rows[0].CancelEdit();
                    break;

                default:
                    table.Rows[0].EndEdit();
                    break;
            }

            Console.WriteLine("Current value: " + table.Rows[0][0]);
        }

      
    }
}
