using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

// испоьзование маппинга таблиц

namespace TableMappings
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();

            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=ShopDB;Integrated Security=True";
            string commandString = "SELECT * FROM Customers; SELECT * FROM Employees";

            SqlDataAdapter adapter = new SqlDataAdapter(commandString, connectionString);
            adapter.TableMappings.Add("Table", "Customers"); // объект TableMapping стоит использовать для задания своих имен для таблиц, генерируемых адаптером данных
            adapter.TableMappings.Add("Table1", "Employees"); //

            adapter.Fill(ds);

            label1.Text = ds.Tables[0].TableName; // какое имя у первой таблицы в объекте DataSet?
            label2.Text = ds.Tables[1].TableName; // какое имя у второй таблице в объекте DataSet?

            dataGridView1.DataSource = ds.Tables[0];
            dataGridView2.DataSource = ds.Tables[1];
        }
    }
}
