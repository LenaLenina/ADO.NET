using System;
using System.Data;
using System.Data.SqlClient;

// вывод плана подчинения с помощью рекурсивного метода

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
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

            adapter.Fill(shopDB);

            var employees = shopDB.Tables[0];

            // создание связи сам к себе
            var employeeToHimSelf = shopDB.Relations.Add("Employee_Employee", employees.Columns["EmployeeID"], employees.Columns["ManagerEmpID"]);

            foreach (DataRow employee in employees.Rows)
            {
                ShowSubordinates(employee, employeeToHimSelf, ""); // вызов рекурсивного метода, выводящего план подчинения
                Console.WriteLine();
            }
        }

        private static void ShowSubordinates(DataRow employee, DataRelation relation, string indent)
        {
            Console.WriteLine(indent + employee[1] + " " + employee[2]);

            indent += " "; // отступ

            foreach (DataRow subordinate in employee.GetChildRows(relation))
                ShowSubordinates(subordinate, relation, indent); // рекурсивный вызов метода для близжайшего подчиненного
        }
    }
}
