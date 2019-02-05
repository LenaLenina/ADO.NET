using System;
using System.Data;
using System.Data.SqlClient;

// Создание отношений между таблицами

namespace Relations
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=ShopDB;Integrated Security=True";
            string commandString = "SELECT * FROM Products; SELECt * FROM OrderDetails;";

            DataSet shopDB = new DataSet("ShopDB");

            SqlDataAdapter adapter = new SqlDataAdapter(commandString, connectionString);

            adapter.Fill(shopDB); // заполнение DataSet

            DataTable products = shopDB.Tables[0];      // получение ссылки на таблицу Products
            DataTable orderDetails = shopDB.Tables[1];  // получение ссылки на таблицу OrderDetails

            // создание отношения между таблицами Products и OrderDetails
            var ProductsOrderDetailsRel = new DataRelation("Products_OrderDetails",             // имя отношения 
                                                            products.Columns["ProdID"],         // поле родительской таблицы
                                                            orderDetails.Columns["ProdID"],     // поле дочерней таблицы
                                                            true);                              // создавать/не создавать ограничения

            // после созания ограничения его нужно добавить в коллекцию Relations объекта DataSet, в которой содержаться таблицы
            // без этого шага отношение не будет работать
            shopDB.Relations.Add(ProductsOrderDetailsRel);

            Console.WriteLine("Products primary key columns number: " + products.PrimaryKey.Length);          // объект DataRelation не добавляет ограничение первичного ключа
            Console.WriteLine("ProdID column Unique= " + products.Columns["ProdID"].Unique);                //столбцу родительской таблицы добавлено ограничение на уникальность 
            Console.WriteLine("ProdID column AllowDBNull= " + products.Columns["ProdID"].AllowDBNull);      //столбцу родительской таблицы добавлено ограничение на уникальность 

            var orderDetailsConstraint = orderDetails.Constraints[0] as ForeignKeyConstraint;
            Console.WriteLine("OrderDetails foreign key constraint name: " + orderDetailsConstraint.ConstraintName); // добавлено ограничение ForeignKeyConstraint
        }
    }
}
