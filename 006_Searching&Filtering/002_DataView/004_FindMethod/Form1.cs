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

namespace Filtering
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

            customers.TableName = "Customers";

            adapter = new SqlDataAdapter(commandString, connectionString);
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

            adapter.Fill(customers);

            customersView = new DataView(customers, "", "City", DataViewRowState.CurrentRows);

            dataGridView1.DataSource = customers;
        }

        private void findButton_Click(object sender, EventArgs e)
        {
            int index = customersView.Find(iDToFindTextBox.Text);

            // Сложно реализовать привязку
            if (index != -1)
            {
                DataRow row = customers.Rows[index - 1];

                iDTextBox.Text = row["CustomerNo"].ToString();
                fNameTextBox.Text = row["FName"].ToString();
                lNameTextBox.Text = row["LName"].ToString();
                addressTextBox.Text = row["Address1"].ToString();
                cityTextBox.Text = row["City"].ToString();
                phoneTextBox.Text = row["Phone"].ToString();
            }
            else
                MessageBox.Show(string.Format("Клиента с ID = {0} не найдено", iDToFindTextBox.Text));
        }

        private void updateCustomerButton_Click(object sender, EventArgs e)
        {
            // Логика обновления
        }
    }
}
