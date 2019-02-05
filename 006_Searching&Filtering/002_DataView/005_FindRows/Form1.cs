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

namespace Searching
{
    public partial class Form1 : Form
    {
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=ShopDB;Integrated Security=True";
        string commandString = "SELECT * FROM Customers";

        DataTable customers = new DataTable();
        SqlDataAdapter adapter;
        DataView customersView;

        public Form1()
        {
            InitializeComponent();

            adapter = new SqlDataAdapter(commandString, connectionString);
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            adapter.Fill(customers);

             customersView = new DataView(customers, "", "City", DataViewRowState.CurrentRows);
 
             dataGridView1.DataSource = customers;
        }

        private void button1_Click(object sender, EventArgs e)
        {
             DataRowView[] findingRows = customersView.FindRows(textBox1.Text);

            dataGridView2.DataSource = findingRows.ToList();
        }
    }
}
