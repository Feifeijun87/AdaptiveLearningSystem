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
    public partial class CourseDetails : System.Web.UI.Page
    {
  
        SqlConnection conn = new SqlConnection(@"Data Source=ASUS\SQLSERVER;Initial Catalog=fyp;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            lblErrorMessage.Visible = false;
            if (!IsPostBack) {
                lblErrorMessage.Visible = false;
                conn.Open();
                    SqlCommand cmd = new SqlCommand("prc_course_group", conn);
                    cmd.Parameters.AddWithValue("@CourseID", Request.QueryString["course"].ToString());
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = cmd;
                    DataSet dt = new DataSet();
                    sda.Fill(dt);
                    chkboxTutorialGroup.DataSource = dt;
                    chkboxTutorialGroup.DataTextField = "TutorialGrpName";
                    chkboxTutorialGroup.DataValueField = "TutorialGrpID";
                    chkboxTutorialGroup.DataBind();
                conn.Close();
            }

            
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {

            Response.Redirect("CourseList.aspx");
            
        }



        protected void btnConfrim_Click(object sender, EventArgs e)
        {
            int count = 0;
            conn.Open();
            foreach (ListItem row in chkboxTutorialGroup.Items)
            {
                      
                if (row.Selected)
                {
                    count++;
                    SqlCommand cmd = new SqlCommand("prc_enroll_course", conn);
                    cmd.Parameters.AddWithValue("@CourseID", Request.QueryString["course"].ToString());
                    cmd.Parameters.AddWithValue("@TutorialGrpID", row.Value.ToString());
                    cmd.Parameters.AddWithValue("@LecturerID", Session["lecturerID"].ToString());
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter writePass = new SqlDataAdapter();
                    writePass.UpdateCommand = cmd;
                    writePass.UpdateCommand.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }
            
            conn.Close();

            if(count <= 0)
            {
                lblErrorMessage.Visible = true;
                lblErrorMessage.Text = "Please choose at least one tutorial group";
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Enroll Successfully'); window.location.href='CourseList.aspx';", true);
            }
        }


    }
}