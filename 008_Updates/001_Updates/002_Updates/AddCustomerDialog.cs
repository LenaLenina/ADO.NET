using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Updates
{
    public partial class AddCustomerDialog : Form
    {

        DataTable table;

        public AddCustomerDialog(DataTable table)
        {
            this.table = table;

            InitializeComponent();
        }

        private void AddCustomerDialog_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(table.Columns["LName"].AllowDBNull.ToString());
            this.CenterToScreen();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataRow newRow = table.NewRow();
            newRow["FName"] = textBox1.Text.Count() == 0 ? null : textBox1.Text;
            newRow["LName"] = textBox2.Text.Count() == 0 ? null : textBox2.Text;
            newRow["Address1"] = textBox3.Text.Count() == 0 ? null : textBox3.Text;
            newRow["City"] = textBox4.Text.Count() == 0 ? null : textBox4.Text;
            newRow["Phone"] = textBox5.Text.Count() == 0 ? null : textBox5.Text;

            try
            {
                table.Rows.Add(newRow);

                DialogResult = System.Windows.Forms.DialogResult.OK;

                CustomersUpdates.InsertCustomers(table);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Close();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
