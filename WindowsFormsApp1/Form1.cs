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

            // >>  IQueryable  IEnumerable  List

            //LINQ >>JOIN 
            //var result = from category in db.Categories 
            //    where category.CategoryID<=10
            //    select new
            //    {
            //        categoryID = category.CategoryID,
            //        categoryName = category.CategoryName
            //    };

            //lambda

            //var result2 = db.Categories.Where(x => x.CategoryID <= 10).Select(x => new TempModel
            //{
            //    CategoryID = x.CategoryID,
            //    CategoryName = x.CategoryName
            //});

            

            var strSQL = "Select CategoryID,CategoryName From  Categories Where CategoryID<=@CategoryID";

            List<SqlParameter> paras = new List<SqlParameter>();

            paras.Add(new SqlParameter("@CategoryID", 10));

            var sqlResult = db.Database.SqlQuery<TempModel>(strSQL, paras.ToArray()).ToList();

            dataGridView1.DataSource = sqlResult.ToList();

        }
    }

    public class TempModel
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}
