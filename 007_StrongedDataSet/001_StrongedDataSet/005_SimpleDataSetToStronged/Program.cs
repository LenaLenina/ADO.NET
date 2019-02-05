using System;
using System.Data;
using System.Data.SqlClient;

// Использование метода Merge для слияния таблиц для строготипизированного и обычного DataSet

namespace GetChanges
{
    class Program
    {
        static void Main(string[] args)
        {
            DataSet simpleShopDb = new DataSet();

            simpleShopDb.ReadXmlSchema(@"D:\ADO.NET\DATA\ShopDbSchema.xml");
            simpleShopDb.ReadXml(@"D:\ADO.NET\DATA\ShopDBData.xml");

            ShopDB strongedShopDB = new ShopDB();

            //Слияние обычно применяется для клиентских приложений с целью включения последних изменений из источника данных в существующий класс DataTable. Это позволяет клиентскому приложению иметь класс DataTable, обновленный последними данными из источника.
            strongedShopDB.Customers.Merge(simpleShopDb.Tables["Customers"]);

            foreach (DataRow row in strongedShopDB.Customers.Rows)
            {
                foreach (DataColumn column in strongedShopDB.Customers.Columns)
                    Console.WriteLine("{0}: {1}", column.ColumnName, row[column]);

                Console.WriteLine();
            }
        }
    }
}
