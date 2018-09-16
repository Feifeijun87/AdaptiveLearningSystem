using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Text;
using System.Data;

namespace AdaptiveLearningSystem
{
    public partial class WebForm1 : System.Web.UI.Page
    {
       
        SqlConnection conn = new SqlConnection(@"Data Source=ASUS\SQLSERVER;Initial Catalog=fyp;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUserName.Text = Session["lecName"].ToString();
            SqlCommand cmd = new SqlCommand("prc_tutorial_track", conn);
            cmd.Parameters.AddWithValue("@Username", Session["username"].ToString());           
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            rptrTutorialTrack.DataSource = dt;
            rptrTutorialTrack.DataBind();



        }

        protected int calculatePercentage(int numerator, int denominator) {
            

             double result = Math.Round(( (double)numerator / (double)denominator) * 100);
            int percentage = int.Parse(result.ToString());

            return percentage;
        }


        protected void ProfilesLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("LecProfile.aspx");
        }

        protected void TutorialLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("CourseList.aspx");
        }
    }
}