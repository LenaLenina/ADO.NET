using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace PartOfROws
{
    public partial class Form1 : Form
    {
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=ShopDB;Integrated Security=True";
        string commandString = "SELECT * FROM Customers";
        SqlDataAdapter adapter;
        int i = 0, step = 2;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            adapter = new SqlDataAdapter(commandString, connectionString);
            
            DataTable table = new DataTable();
            adapter.Fill(0, step, table);
            dataGridView1.DataSource = table;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.NextPage(step);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.NextPage(-step);
        }

        private void NextPage(int step)
        {
            DataTable table = new DataTable();
           
            if (step > 0)
                adapter.Fill(i += step, step, table);
            else
                adapter.Fill(i += step, -step, table);

                dataGridView1.DataSource = table;
        }
    }
}
