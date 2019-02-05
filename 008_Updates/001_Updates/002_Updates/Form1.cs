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

namespace Updates
{

    public partial class Form1 : Form
    {
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=ShopDB;Integrated Security=True";
        string commandString = "SELECT * FROM Customers";

        DataTable customers = new DataTable("Customers");
        SqlDataAdapter adapter;

        public Form1()
        {
            InitializeComponent();

            this.CenterToScreen();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            adapter = new SqlDataAdapter(commandString, connectionString);
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
           
            adapter.FillSchema(customers, SchemaType.Mapped);
            customers.Columns["CustomerNo"].AutoIncrementSeed = -1;
            customers.Columns["CustomerNo"].AutoIncrementStep = -1;

            adapter.Fill(customers);

            dataGridView1.DataSource = customers;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult result = new AddCustomerDialog(customers).ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }
    }
}
