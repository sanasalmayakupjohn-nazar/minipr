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
    public partial class Quiz : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"server=LAPTOP-7RQKID5D\SQLEXPRESS;database=MP;Integrated Security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            if (!IsPostBack)
            {
                Session["Index"] = 0;
                Session["Score"] = 0;

                LoadQuestions();
                ShowQuestion();
            }
        }
        public void LoadQuestions()
        {
            string s = "select * from Questions";
            SqlDataAdapter da = new SqlDataAdapter(s, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Session["Questions"] = dt;
        }

        public void ShowQuestion()
        {

            DataTable dt = (DataTable)Session["Questions"];
            int index = (int)Session["Index"];

            if (index < dt.Rows.Count)//checks if the current question index is within the total number of questions.
            {
                DataRow rw = dt.Rows[index];
                lblQuestion.Text = rw["Question"].ToString();//rw is a single row in dt-1 qstn in quiz. dt.Rows[index] fetches the row at the current question’s position (index). Each row has columns like "Question"

                // Clear old options
                rblOptions.Items.Clear();

                // Add new options dynamically with Value = A/B/C/D
                rblOptions.Items.Add(new ListItem("A. " + rw["OptionA"].ToString(), "A"));
                rblOptions.Items.Add(new ListItem("B. " + rw["OptionB"].ToString(), "B"));
                rblOptions.Items.Add(new ListItem("C. " + rw["OptionC"].ToString(), "C"));
                rblOptions.Items.Add(new ListItem("D. " + rw["OptionD"].ToString(), "D"));

                rblOptions.ClearSelection();


            }
            else
            {
                Response.Redirect("Result.aspx");
            }
        }
        protected void btnchk_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)Session["Questions"];
            int index = (int)Session["Index"];
            lblchk.Visible = true;
            lblans.Visible = true;

            // Get the correct answer from the DataTable
            string correctAnswer = dt.Rows[index]["CorrectAnswer"].ToString();

            // Compare user selection with correct answer
            if (rblOptions.SelectedValue == correctAnswer)
            {
               
                lblchk.Text = "✓ Correct!";
                lblchk.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblchk.Text = "✗ Wrong!";
                lblchk.ForeColor = System.Drawing.Color.Red;
            }
            lblans.Text = "Correct Answer: " + correctAnswer;
            lblans.ForeColor = System.Drawing.Color.Blue;

            rblOptions.Enabled = false;
            btnchk.Enabled = false;
            Session["Answered"] = true;
        }
        protected void btnNext_Click(object sender, EventArgs e)
        {

            lblchk.Text = "";
            lblans.Text = "";

            rblOptions.Enabled = true;
            btnchk.Enabled = true;

            DataTable dt = (DataTable)Session["Questions"];
            int index = (int)Session["Index"];

            string correctAnswer = dt.Rows[index]["CorrectAnswer"].ToString();

            if ((bool)Session["Answered"] == false)
            {
                if (rblOptions.SelectedIndex != -1 &&
                    rblOptions.SelectedValue == correctAnswer)
                {
                    Session["Score"] = (int)Session["Score"] + 1;
                }
            }
            // If user already checked
            else
            {
                if (rblOptions.SelectedValue == correctAnswer)
                {
                    Session["Score"] = (int)Session["Score"] + 1;
                }
            }
            // move to next question
            Session["Index"] = (int)Session["Index"] + 1;

            // Show next question
            ShowQuestion();
        }

     
    }
}