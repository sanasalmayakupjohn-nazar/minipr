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
    public partial class AdminQuestions : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"server=LAPTOP-7RQKID5D\SQLEXPRESS;database=MP;Integrated Security=true");

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Buttonadd_Click(object sender, EventArgs e)
        {
            string query = "insert into Questions (Question, OptionA, OptionB, OptionC, OptionD, CorrectAnswer) values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" +TextBox5.Text + "','" + DropDownList1.SelectedItem.Value + "')";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i == 1)
            {
                Label1.Visible = true;
                Label1.Text = "Single question added successfully!";
            }
              
             else
            {
                Label1.Visible = true;
                Label1.Text = "Failed to add question.";
            }

            // Optional: Clear the textboxes for next entry
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            DropDownList1.SelectedIndex = 0;
        }

        protected void Buttonadal_Click(object sender, EventArgs e)
        {
            string query = "insert into Questions (Question, OptionA, OptionB, OptionC, OptionD, CorrectAnswer) values " +
              "('Which is the largest organ in the human body?','Skin','Heart','Liver','Lungs','A')," +
              "('Who is known as the father of the Indian Constitution?','Jawaharlal Nehru','B.R. Ambedkar','Sardar Patel','Mahatma Gandhi','B')," +
              "('Which country is known as the Land of the Rising Sun?','China','Thailand','Japan','South Korea','C')," +
              "('What is the chemical formula of water?','CO2','NaCl','O2','H2O','D')," +
              "('Which is the longest river in India?','Ganga','Yamuna','Godavari','Brahmaputra','A')," +
              "('Which metal is liquid at room temperature?','Iron','Gold','Mercury','Copper','C')," +
              "('Which element has the chemical symbol Fe?','Fluorine','Iron','Fermium','Francium','B')," +
              "('Who painted the ceiling of the Sistine Chapel?','Raphael','Donatello','Leonardo da Vinci','Michelangelo','D')," +
              "('The Great Barrier Reef is located in which country?','India','Australia','USA','South Africa','B')," +
              "('Which planet has the shortest day in the solar system?','Jupiter','Saturn','Mercury','Neptune','A')";

            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            Label1.Visible = true;
            Label1.Text = i + " questions inserted successfully!";
        }
    }
    
}