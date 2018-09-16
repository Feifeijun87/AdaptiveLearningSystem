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
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(@"Data Source=ASUS\SQLSERVER;Initial Catalog=fyp;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                StudentPanel.Visible = false;
                MainPanel.Visible = true;
                LecturerPanel.Visible = false;
            }


        }

        protected void btnStudent_Click(object sender, EventArgs e)
        {
            // Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Successful');</script>");
            
            CategoryPanel.Visible = false;
            StudentPanel.Visible = true;
        }

        protected void btnLecturer_Click(object sender, EventArgs e)
        {
            CategoryPanel.Visible = false;
            LecturerPanel.Visible = true;


        }

        protected void btnLecturerSignIn_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand("prc_lec_details", conn);
            cmd.Parameters.AddWithValue("@Username", txtLecturerID.Text.Trim());
            cmd.Parameters.AddWithValue("@Password", txtLecturerPassword.Text.Trim());
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            SqlDataReader lecturerRead = cmd.ExecuteReader();
            if (!lecturerRead.HasRows)
            {
                lblError.Style.Add("display", "inherit");
                lblError.Text = "Invalid ID or Password.";
            }
            else
            {
                if (lecturerRead.Read())
                {
                    Session["lecturerID"] = lecturerRead.GetString(0).ToString();
                    Session["username"] = lecturerRead.GetString(1).ToString();
                    Session["lecPass"] = lecturerRead.GetString(2).ToString();
                    Session["lecTitle"] = lecturerRead.GetString(3).ToString();
                    Session["lecName"] = lecturerRead.GetString(4).ToString();
                    Session["contactNo"] = lecturerRead.GetString(5).ToString();
                    Session["officeLoc"] = lecturerRead.GetString(6).ToString();
                    Session["email"] = lecturerRead.GetString(7).ToString();
                    Session["address"] = lecturerRead.GetString(8).ToString();
                    Session["position"] = lecturerRead.GetString(9).ToString();
                    Session["lecFaculty"] = lecturerRead.GetString(10).ToString();
                    Session["facultyName"] = lecturerRead.GetString(11).ToString();
                    Response.Redirect("LecHome.aspx");
                }
            }
            conn.Close();
        }

        protected void btnLecturerSignUp_Click(object sender, EventArgs e)
        {


        }

        protected void btnStudentSignIn_Click(object sender, EventArgs e)
        {

        }

        protected void btnLecturerSignUp_Click1(object sender, EventArgs e)
        {

        }

        protected void btnStudentSignUp_Click(object sender, EventArgs e)
        {

        }
    }
}