using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

// создание правил для удаления и обновления данных связанных строк

namespace DeleteRuleWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataSet shopDB = new DataSet();

            shopDB.ReadXmlSchema(@"D:\ADO.NET\DATA\ShopDbSchema.xml");
            shopDB.ReadXml(@"D:\ADO.NET\DATA\ShopDBData.xml");

            shopDB.AcceptChanges();

            DataTable customers = shopDB.Tables["Customers"];
            DataTable orders = shopDB.Tables["Orders"];
            DataTable orderDetails = shopDB.Tables["OrderDetails"];

            var FK_Customers_Orders = orders.Constraints["Customers_Orders"] as ForeignKeyConstraint;
            // при удалении/изменении строки из таблицы Customers будут удаляться/изменяться все связанные строки из таблицы Orders
            FK_Customers_Orders.DeleteRule = Rule.Cascade; 
            FK_Customers_Orders.UpdateRule = Rule.Cascade;
            
            var FK_Orders_OrderDetails = orderDetails.Constraints["Orders_OrderDetails"] as ForeignKeyConstraint;
            FK_Orders_OrderDetails.DeleteRule = Rule.Cascade; //при удалении строки из таблицы Customers будет ошибка

            label1.Text = customers.TableName;
            dataGridView1.DataSource = customers; // связывание таблицы customers c элементом управления dataGridView1

            label2.Text = orders.TableName;
            dataGridView2.DataSource = orders; // связывание таблицы orders c элементом управления dataGridView2

            label3.Text = orderDetails.TableName;
            dataGridView3.DataSource = orderDetails;
        }
    }
}
