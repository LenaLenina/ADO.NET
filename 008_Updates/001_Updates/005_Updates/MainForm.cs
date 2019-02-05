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
using Updates.Commands;

namespace Updates
{
    public partial class MainForm : Form
    {
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=ShopDB;Integrated Security=True";
        string commandString = "SELECT * FROM Customers";

        DataTable customers = new DataTable("Customers");

        public MainForm()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(commandString, connectionString);
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            adapter.Fill(customers);

            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = customers;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult result = new AddCustomerDialog(customers).ShowDialog();
        }

        private void modifyButton_Click(object sender, EventArgs e)
        {
            var editDialog = new EditCustomerDialog(customers, (dataGridView1.CurrentRow.DataBoundItem as DataRowView).Row);

            editDialog.ShowDialog();

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Вы уверены что хотите удалить этого клиента?", "DeleteDialog", MessageBoxButtons.OKCancel);

            if (res == System.Windows.Forms.DialogResult.OK)
            {
                var rowToDelete = (dataGridView1.CurrentRow.DataBoundItem as DataRowView).Row;
                rowToDelete.Delete();

                CustomersUpdates.DeleteCustomers(rowToDelete);
            }
        }


    }
}
