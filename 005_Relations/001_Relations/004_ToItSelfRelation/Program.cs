using System;
using System.Data;
using System.Data.SqlClient;

// Работа со связью сам к себе. Получение данных при связи сам к себе

namespace ToItSelfRelation
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=ShopDB;Integrated Security=True";

            DataSet shopDB = new DataSet("ShopDB");

            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Employees", connectionString);
            adapter.TableMappings.Add("Table", "Employees");
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey; // копирование схемы и создание первичных ключей на таблицах

            adapter.Fill(shopDB);

            var employees = shopDB.Tables[0];

            shopDB.Relations.Add("Employee_Employee", employees.Columns["EmployeeID"], employees.Columns["ManagerEmpID"], false); // создание связи сам к себе

            foreach (DataRow employee in employees.Rows)
            {
                DataRow manager = employee.GetParentRow("Employee_Employee"); // получение непосредственного начальника

                if (manager != null)
                {
                    string empName = employee[1] + " " + employee[2];
                    string managerName = manager[1] + " " + manager[2];
                    Console.WriteLine(empName + " подчиняется " + managerName); 
                }
            }
        }
    }
}
                