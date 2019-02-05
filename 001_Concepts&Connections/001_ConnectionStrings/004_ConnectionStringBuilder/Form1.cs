#define SetProperty

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
// Пошаговая инструкция по созданию базы данных и пользователя находится в файле CreatingEvelDB.xps 

namespace CBS.ADO_NET.ConnectionStringBuilder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder(); // создание конструктора строк подключения 

#if SetProperty

            connectionStringBuilder.DataSource = @".\SQLEXPRESS";       // используйте конструктор строк подключения для 
            connectionStringBuilder.InitialCatalog = "ShopDB";          // предотвращения изменения пользователем структуры строки подключения
            connectionStringBuilder.UserID = userNameTextBox.Text;      
            connectionStringBuilder.Password = passwordTextBox.Text;    
#else 
            connectionStringBuilder["Data Source"] = @".\SQLEXPRESS";   // используйте конструктор строк подключения для 
            connectionStringBuilder["Initial Catalog"] = "ShopDB";      // предотвращения изменения пользователем структуры строки подключения
            connectionStringBuilder["User ID"] = userNameTextBox.Text;
            connectionStringBuilder["Password"] = passwordTextBox.Text;
#endif
            using (SqlConnection connection = new SqlConnection(connectionStringBuilder.ConnectionString))
            {
                try
                {
                    connection.Open();
                    MessageBox.Show("Connection opened to " + connection.Database);

                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }

            }
        }

    }
}
