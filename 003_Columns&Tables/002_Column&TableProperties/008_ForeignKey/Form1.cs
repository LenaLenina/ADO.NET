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

// 

namespace CBS.ADO_NET.TableConstraints
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=.\SQLEXPRESS; Initial Catalog=ShopDB; Integrated Security=True;"; // создание строки подключения

            DataSet ds = new DataSet();
            DataTable customers = new DataTable("Customers");
            DataTable orders = new DataTable("Orders");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand customersCmd = new SqlCommand("SELECT CustomerNo, LName, FName, Address1, Phone FROM Customers", connection);
                SqlCommand ordersCmd = new SqlCommand("SELECT OrderID, CustomerNo, OrderDate FROM Orders", connection);

                SqlDataReader ordersReader = ordersCmd.ExecuteReader(); // получение DataReader для таблицы OrderDetails

                // метод LoadWithSchema позволяет на основе объекта DataReader создать объект DataTable 
                //с ограничениями для столбцов как в базе данных и заполнить эту таблицу данными
                orders.LoadWithSchema(ordersReader);
                ordersReader.Close();

                SqlDataReader customersReader = customersCmd.ExecuteReader();
                customers.LoadWithSchema(customersReader);
                customersReader.Close();
            }

            // объект DataReader не имеет информации об ограничениях объектов DataTable, таких как 
            // UniqueConstraint, ForeignKeyConstraint и PrimaryKey, поэтому прийдется их создать вручную
            customers.PrimaryKey = new DataColumn[] { customers.Columns[0] };

            ds.Tables.AddRange(new DataTable[] { customers, orders });

            // создание ограничения ForeignKeyConstraint для таблицы OrderDetails
            var FK_CustomersOrders = new ForeignKeyConstraint(customers.Columns["CustomerNo"], orders.Columns["CustomerNo"]);
            orders.Constraints.Add(FK_CustomersOrders);

            parentGridView.DataSource = customers; // связывание элемента управления parentGridView с таблицей Products
            childDataGridView.DataSource = orders; // Связывание элемента управления childDataGridView c таблицей OrderDetails
        }
    }
}
