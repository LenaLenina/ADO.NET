using System;
using System.Data;

// ForeignKeyConstraint – ограничение, гарантирующее что нельзя создать строку в дочерней таблице, которая ссылается на несуществующую строку родительской таблицы.


namespace CBS.ADO_NET.TableConstraints
{
    class Program
    {
        static void Main(string[] args)
        {
            DataSet ds = new DataSet(); // создание DataSet

            DataTable parentTable = new DataTable(); // родительская таблица
            DataTable childTable = new DataTable(); // дочерняя таблица

            DataColumn childColumn = childTable.Columns.Add("ChildColumn", typeof(int));
            DataColumn parentColumn = parentTable.Columns.Add("ParentColumn", typeof(int));

            // ограничение ForeignKeyConstraint будет работать если родительская и дочерняя таблица находятся в одном объекте DataSet
            ds.Tables.AddRange(new DataTable[] { childTable, parentTable }); 

            parentTable.Constraints.Add(new UniqueConstraint(parentColumn));
            childTable.Constraints.Add(new ForeignKeyConstraint(parentColumn, childColumn)); 

            DataRow parentRow = parentTable.NewRow();
            parentRow[0] = 1;
            parentTable.Rows.Add(parentRow);

            DataRow childRow = childTable.NewRow();
            childRow[0] = 1;

            // после создания ограничения ForeignKeyConstraint нельзя добавлять в дочернюю таблицу строку, ссылающиеся на несуществующие строки из родительской таблицы
            childRow[0] = 0; 
            childTable.Rows.Add(childRow);
        }
    }
}
