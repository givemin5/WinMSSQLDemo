using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Models;
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
            NorthwindEntities1 db = new NorthwindEntities1();


            //LINQ
            //var result = from category in db.Categories 
            //    where category.CategoryID<=10
            //    select new
            //    {
            //        categoryID = category.CategoryID,
            //        categoryName = category.CategoryName
            //    };

            //lambda
            var result2 = db.Categories.Where(x => x.CategoryID <= 10).Select(x => new
            {
                categoryID = x.CategoryID,
                categoryName = x.CategoryName
            });
            
            dataGridView1.DataSource = result2.ToList();

        }
    }
}
