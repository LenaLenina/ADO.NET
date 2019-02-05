using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace фDataView
{
    public partial class Form1 : Form
    {
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=ShopDB;Integrated Security=True";
        string commandString = "SELECT * FROM Customers";

        DataTable customers = new DataTable();
        DataView view;

        public Form1()
        {
            InitializeComponent();

            SqlDataAdapter adapter = new SqlDataAdapter(commandString, connectionString);
            adapter.Fill(customers);

            view = new DataView(customers);

            dataGridView1.DataSource = customers;
            dataGridView2.DataSource = view;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            view.RowFilter = textBox1.Text;
            view.Sort = textBox2.Text;

            view.RowStateFilter = (DataViewRowState)Enum.Parse(typeof(DataViewRowState), comboBox1.Text, true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            customers.AcceptChanges();
        }
    }
}
