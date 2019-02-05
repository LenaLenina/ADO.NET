using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Соединяющие запросы Linq

namespace JoinsWork
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataSet ShopDB = new DataSet();

            ShopDB.ReadXmlSchema(@"D:\ADO.NET\DATA\ShopDbSchema.xml");
            ShopDB.ReadXml(@"D:\ADO.NET\DATA\ShopDbData.xml");

            var customers = ShopDB.Tables["Customers"];
            var orders = ShopDB.Tables["Orders"];
            var orderDetails = ShopDB.Tables["OrderDetails"];
            var products = ShopDB.Tables["Products"];

            var query = from customer in customers.AsEnumerable()
                        from order in orders.AsEnumerable()
                        from orderDetail in orderDetails.AsEnumerable()
                        from product in products.AsEnumerable()

                        where (int)customer["CustomerNo"] == (int)order["CustomerNo"] &&
                              (int)order["OrderId"] == (int)orderDetail["OrderId"] &&
                              (int)orderDetail["ProdID"] == (int)product["ProdID"]

                        select new
                        {
                            Customer = customer["LName"].ToString() + " " + customer["FName"].ToString(),
                            OrderDate = order["OrderDate"],
                            LineItem = orderDetail["LineItem"],
                            TotalPrice = orderDetail["TotalPrice"],
                            Description = product["Description"].ToString().Trim()
                        };


            dataGridView1.DataSource = query.ToList();
           
        }
    }
}
