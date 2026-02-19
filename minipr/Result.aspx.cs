using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace minipr
{
    public partial class Result : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"server=LAPTOP-7RQKID5D\SQLEXPRESS;database=MP;Integrated Security=true");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Get user name and score directly from session
                string userName = Session["UserName"].ToString();
                int score = (int)Session["Score"];

                string sqlDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                lblUser.Text = "Hello, " + userName + "!";
                lblScore.Text = "Your Score: " + score;

                string query = "insert into Results(UserName, Score, TestDate) values('"+ userName + "', " + score + ", '" + sqlDate + "')";
                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}