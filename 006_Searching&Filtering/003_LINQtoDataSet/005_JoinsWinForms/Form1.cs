using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

// Реализация Left outer join в Linq

namespace JoinsWinForms
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
                        join order in orders.AsEnumerable()
                        on customer["CustomerNo"] equals order["CustomerNo"] into ordersGroup

                        from order in ordersGroup.DefaultIfEmpty() // DefaultIfEmpty вернет null, если не существует связанных данных
                        join orderDetail in orderDetails.AsEnumerable()
                        on (order == null) ? null : order["OrderId"] equals orderDetail["OrderId"] into orderdetailsGroup

                        select
                        new
                        {
                            FName = customer["FName"],
                            Sum = orderdetailsGroup.Sum(a => Convert.ToDecimal(a["totalPrice"]))
                        };

            dataGridView1.DataSource = query.ToList();
        }
    }
}
