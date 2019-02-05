using System;
using System.Data;
using System.Data.SqlClient;

// просмотр связанных данных строки, подготовленной к удалению

namespace RelationsRowState
{
    class Program
    {
        static void Main(string[] args)
        {
            DataSet shopDB = new DataSet();

            shopDB.ReadXmlSchema(@"D:\ADO.NET\DATA\ShopDbSchema.xml");
            shopDB.ReadXml(@"D:\ADO.NET\DATA\ShopDBData.xml");

            shopDB.AcceptChanges();

            DataTable orders = shopDB.Tables["Orders"];
            DataTable customers = shopDB.Tables["Customers"];

            // ForeignKeyConstraint FK_Customers_Orders = orders.Constraints["Customers_Orders"] as ForeignKeyConstraint;
            // FK_Customers_Orders.DeleteRule = Rule.SetNull;

            customers.Rows[0].Delete();

            var ordersChildRows = customers.Rows[0].GetChildRows("Customers_Orders", DataRowVersion.Original);
            // ordersChildRows = customers.Rows[0].GetChildRows("Customers_Orders");

            foreach (var ordersRow in ordersChildRows)
                Console.WriteLine("OrderID: {0}, orderDate: {1:D}",ordersRow[0, DataRowVersion.Original], ordersRow[2, DataRowVersion.Original]);
            
        }


    }
}
