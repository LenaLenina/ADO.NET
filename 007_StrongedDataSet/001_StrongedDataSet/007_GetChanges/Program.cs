using System;
using System.Data;
using System.Data.SqlClient;

// Использование метода GetChanges для получения DataSet только с измененными данными

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

            strongedShopDB.Customers.Merge(simpleShopDb.Tables["Customers"]);
            strongedShopDB.AcceptChanges();

            var selectedCustomer = strongedShopDB.Customers.FindByCustomerNo(1);
            selectedCustomer.Phone = "New Value";

            // Метод GetChanes() получает копию класса DataSet, содержащую все изменения, внесенные после его последней загрузки или после вызова метода AcceptChanges.
            DataSet datasetWithChanges = strongedShopDB.GetChanges();

            ShopDB inst = datasetWithChanges as ShopDB;

            foreach (DataRow row in datasetWithChanges.Tables["Customers"].Rows)
            {
                foreach (DataColumn column in datasetWithChanges.Tables["Customers"].Columns)
                    Console.WriteLine("{0}: {1}", column.ColumnName, row[column]);
            }
        }
    }
}
