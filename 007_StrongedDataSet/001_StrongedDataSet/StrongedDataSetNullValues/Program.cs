﻿using System;
using System.Data;
using System.Data.SqlClient;

// Работа со значениями NULL в строго типизированном DataSet

namespace GetChanges
{
    class Program
    {
        static void Main(string[] args)
        {
            ShopDB shopDB = new ShopDB();

            ShopDB.CustomersRow customersRow = shopDB.Customers.NewCustomersRow();

            shopDB.Customers.AddCustomersRow("Николай", "Александров", "Анатольевич", "Московская 15", null, "Чернигов", "(063)0215478", new DateTime(2008, 05, 15));
            shopDB.Customers.AddCustomersRow("Константин", "Нимазов", "Алексеевич", "Октябрьская 5", null, "Киев", "(093)5487478", new DateTime(2009, 06, 20));
            shopDB.Customers.AddCustomersRow("Андрей", "Макин", "Абрамович", "Сеновальная 7", null, "Витебск", "(098)7123478", new DateTime(2006, 12, 1));

            var selectedCustomer = shopDB.Customers.FindByCustomerNo(-3);

            selectedCustomer.BeginEdit();
            selectedCustomer.SetMNameNull(); // присвоение полю строки значния DbNull.Value
            selectedCustomer.EndEdit();

            Console.WriteLine("Last name: " + selectedCustomer.LName);
            Console.WriteLine("First name: " + selectedCustomer.FName);
           
            if (selectedCustomer.IsMNameNull()) // проверка на DbNull.Value
                Console.WriteLine("Middle name: no data");
            else
                Console.WriteLine("Middle name: "+ selectedCustomer.MName);

            Console.WriteLine("Phone: " + selectedCustomer.Phone);


        }
    }
}
