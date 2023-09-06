using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //資料庫的連線字串
            string connectionString = 
                "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=Northwind;"
                + "user id=anyo;pwd=123456";

            // SQL
            string queryString = @"SELECT ProductID, UnitPrice, ProductName from dbo.products 
WHERE UnitPrice > @pricePoint ORDER BY UnitPrice DESC;";


            //連線的 class 
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                //  SqlCommand command = connection.CreateCommand();
                SqlCommand command = new SqlCommand(queryString, connection);

                int paramValue = 5;
                command.Parameters.AddWithValue("@pricePoint", paramValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    

                    DataTable dt = new DataTable();

                    dt.Load(reader);

                    reader.Close();

                    dataGridView1.DataSource = dt;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.ReadLine();
            }
        }
    }
}
