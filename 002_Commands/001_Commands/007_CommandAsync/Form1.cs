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

// Асинхронное выполнение команд и подключение к источнику данных

namespace CBS.ADO_NET.ExecuteAsync
{
    public partial class Form1 : Form
    {

        string conStr = @"Data Source=.\SQLEXPRESS; Initial Catalog=ShopDB; Integrated Security=True;"; // создание строки подключения

        public Form1()
        {
            InitializeComponent();
        }

        private void getDataButton_Click(object sender, EventArgs e)
        {
            using(SqlConnection connection = new SqlConnection(conStr))
            {
                connection.Open();      // простое открытие соединения

                SqlCommand cmd = new SqlCommand("WAITFOR DELAY '00:00:10'", connection); // простое выполнение команады

                cmd.ExecuteNonQuery();
                MessageBox.Show("Simple command executed");
            }
        }

        async private void getdataAsyncButtom_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                await connection.OpenAsync();   // асинхронное открытие соединения

                SqlCommand cmd = new SqlCommand("WAITFOR DELAY '00:00:10'", connection); // асинхронное выполнение команды

                await cmd.ExecuteNonQueryAsync();
                MessageBox.Show("Command executed async");
            }
        }


        void timer_Tick(object sender, System.EventArgs e)
        {
            if (progressBar1.Value >= 100)
                progressBar1.Value = 0;

            if (progressBar2.Value >= 100)
                progressBar2.Value = 0;

            if (progressBar3.Value >= 100)
                progressBar3.Value = 0;

            progressBar1.Value += 1;
            progressBar2.Value += 5;
            progressBar3.Value += 2;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer.Start();
        }

    }
}
