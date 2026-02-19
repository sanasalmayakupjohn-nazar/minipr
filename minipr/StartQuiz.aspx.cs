using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace minipr
{
    public partial class StartQuiz : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["UserName"] = "";
            Session["Index"] = 0;
            Session["Score"] = 0;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["UserName"] = TextName.Text.Trim();
            Response.Redirect("Quiz.aspx");
        }
    }
}