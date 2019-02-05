using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

// создание таблиц с ограничениями с помощью DataAdapter

namespace MissingSchema
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();

            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=ShopDB;Integrated Security=True";
            string commandString = 
                "SELECT CUstomerNo, LName, FName, MName, Address1, Phone FROM Customers;"+
                "SELECT OrderID, CustomerNo, OrderDate FROM Orders";

            SqlDataAdapter adapter = new SqlDataAdapter(commandString, connectionString);

            // используя свойство MissingSchemaAction можно заставить адаптер данных создавать ограничения для таблиц
            // ограничения ForeignKeyConstraint с помощью адаптера данных создать нельзя
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey; 
            
            adapter.TableMappings.Add("Table", "Customers");
            adapter.TableMappings.Add("Table1", "Orders");

            adapter.Fill(ds);

            // Ограничения уровня объекта DataTable прийдется создавать вручную
            var FK_CustomersOrders = new ForeignKeyConstraint("FK_CustomersOrders", 
                                                              ds.Tables[0].Columns["CustomerNo"],
                                                              ds.Tables[1].Columns["CustomerNo"]);

            ds.Tables["Orders"].Constraints.Add(FK_CustomersOrders);

            label1.Text = ds.Tables[0].TableName; // какое имя у первой таблицы в объекте DataSet?
            label2.Text = ds.Tables[1].TableName; // какое имя у второй таблице в объекте DataSet?

            dataGridView1.DataSource = ds.Tables[0];
            dataGridView2.DataSource = ds.Tables[1];
        }
    }
}
