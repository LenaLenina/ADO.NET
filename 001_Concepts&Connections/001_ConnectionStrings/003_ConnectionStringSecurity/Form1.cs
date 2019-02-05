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

// Для демонстрации этой программы нужно создать базу данных EvelDB, а так же зарегистрировать пользователя SQLServer
// Пошаговая инструкция по созданию базы данных и пользователя находится в файле "CreatingEvelDB.xps". 

namespace CBS.ADO_NET.ConnectionStringSecurity
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string conStr = @"Data Source=.\SQLEXPRESS;Initial Catalog=ShopDB;" + // построение строки подключения
            "User ID=" + userNameTextBox.Text + ";" +
            "Password=" + passwordTextBox.Text + ";";

            using (SqlConnection connection = new SqlConnection(conStr))
            {
                try
                {
                    connection.Open();
                    MessageBox.Show("Connection opened to " + connection.Database); // вывод на экран информации о подключении к базе данных
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }     
    }
}
