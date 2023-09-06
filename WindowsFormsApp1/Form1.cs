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

        public DataTable Reader(string strSQL, List<SqlParameter> paras)
        {
            //1. SqlConnection、SqlCommand、SqlReader >> DataTable ==> MingDataReader > sql,para>>Datable 

        }

        private void button1_Click(object sender, EventArgs e)
        {

            //1. SqlConnection、SqlCommand、SqlReader
            //2. EntityFramework LINQ 、 Lambda
            //3. Dapper (非 MS SQL ) 
            //4. MS SQL >>有下 SQL 的需求(例如 join 很多表的時候) >>  db.Database.SqlQuery<T>
            //5.  IQueryable、  IEnumerable、 List 差別
            //6. MVC Controller >> 回傳給　Client　一定要是　ｌｉｓｔ
            //7. Stored Procedure



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
