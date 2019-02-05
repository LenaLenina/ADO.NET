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

// Использование объекта DataAdapter

namespace FillDataSetExample
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

            adapter.Fill(ds); // заполнение DataSet данными с помощью DataAdapter
            
            // Объект DataAdapter по умолчанию не создает ограничения для столбцов таблиц

            label1.Text = ds.Tables[0].TableName; // какое имя у первой таблицы в объекте DataSet?
            label2.Text = ds.Tables[1].TableName; // какое имя у второй таблице в объекте DataSet?

            dataGridView1.DataSource = ds.Tables[0]; // Связывание первой таблицы DataSet с элементом управления dataGridView1
            dataGridView2.DataSource = ds.Tables[1]; // Связывание второй таблицы DataSet с элементом управления dataGridView2
        }
    }
}
