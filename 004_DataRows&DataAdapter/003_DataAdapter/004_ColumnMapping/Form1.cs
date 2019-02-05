using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Common;

// использование маппинга столбцов таблиц

namespace ColumnMapping
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
            string commandString = "SELECT * FROM Customers; SELECT * FROM Employees";

            SqlDataAdapter adapter = new SqlDataAdapter(commandString, connectionString);

            adapter.MissingMappingAction = MissingMappingAction.Passthrough; 

            DataTableMapping customersMapping = adapter.TableMappings.Add("Table", "Customers");
            var cusomersColumnMappings = new DataColumnMapping[]
            {
                new DataColumnMapping("CustomerNo", "ID"),      // переименовать CustomerNo в ID
                new DataColumnMapping("FName", "Имя"),          // переименовать FName в Имя
                new DataColumnMapping("LName","Фамилия"),       // переименовать LName в Фамимлия
                new DataColumnMapping("MName","Отчество"),      // ....
                new DataColumnMapping("Address1","Адрес1"),
                new DataColumnMapping("Address2","Адрес2"),
                new DataColumnMapping("City","Город"),
                new DataColumnMapping("Phone","Номер телефона"),
                new DataColumnMapping("DateInSystem","Дата регистрации")
            };
            customersMapping.ColumnMappings.AddRange(cusomersColumnMappings);

            DataTableMapping employeesMapping = adapter.TableMappings.Add("Table1", "Employees");
            var employeesColumnMappings = new DataColumnMapping[]
            {
                new DataColumnMapping("EmployeeID", "ID"),
                new DataColumnMapping("FName", "Имя"),
                new DataColumnMapping("LName","Фамилия"),
                new DataColumnMapping("MName","Отчество"),
                new DataColumnMapping("Salary","Ставка"),
                new DataColumnMapping("PriorSalary","Премия"),
                new DataColumnMapping("HireDate","Дата приема"),
                new DataColumnMapping("TerminationDate","Дата увольнения"),
                new DataColumnMapping("ManagerEmpID","ID менеджера")
            };
            employeesMapping.ColumnMappings.AddRange(employeesColumnMappings);

            adapter.Fill(ds);

            label1.Text = ds.Tables[0].TableName; // какое имя у первой таблицы в объекте DataSet?
            label2.Text = ds.Tables[1].TableName; // какое имя у второй таблице в объекте DataSet?

            dataGridView1.DataSource = ds.Tables[0];
            dataGridView2.DataSource = ds.Tables[1];
        }
    }
}
