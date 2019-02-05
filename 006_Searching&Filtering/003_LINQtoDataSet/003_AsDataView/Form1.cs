using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            DataSet ShopDB = new DataSet();

            ShopDB.ReadXmlSchema(@"D:\ADO.NET\DATA\ShopDbSchema.xml");
            ShopDB.ReadXml(@"D:\ADO.NET\DATA\ShopDbData.xml");

            var customers = ShopDB.Tables["Customers"];
            //var orders = ShopDB.Tables["Orders"];
            //var orderDetails = ShopDB.Tables["OrderDetails"];
            //var products = ShopDB.Tables["Products"];

            InitializeComponent();


            var query = from cust in customers.AsEnumerable()
                        where cust.Field<int>("CustomerNo") == 1 || cust.Field<int>("CustomerNo") == 2
                        orderby cust["CustomerNo"] descending
                        select cust;

            dataGridView2.DataSource = query.AsDataView();

            dataGridView1.DataSource = customers;
        }
    }
}
