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

        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(commandString, connectionString);
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            adapter.Fill(customers);

            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = customers;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult res =  MessageBox.Show("Вы уверены что хотите удалить этого клиента?", "DeleteDialog", MessageBoxButtons.OKCancel);

            if (res == System.Windows.Forms.DialogResult.OK)
            {
                (dataGridView1.CurrentRow.DataBoundItem as DataRowView).Row.Delete();

                CustomersUpdates.DeleteCustomers(customers);
            }
            
        }
    }
}
