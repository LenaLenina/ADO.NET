using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

// Поиск строк с помощью представления. Метод Find

namespace Filtering
{
    class Program
    {
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }
    }
}
