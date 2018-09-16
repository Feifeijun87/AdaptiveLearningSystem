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
    public partial class WebForm2 : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(@"Data Source=ASUS\SQLSERVER;Initial Catalog=fyp;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { 
            SqlCommand cmd = new SqlCommand("prc_course_group", conn);
            cmd.Parameters.AddWithValue("@CourseID", "BaiT3094");
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            DataSet dt = new DataSet();
            sda.Fill(dt);
            CheckBoxList1.DataSource = dt;
            CheckBoxList1.DataTextField = "TutorialGrpName";
            CheckBoxList1.DataValueField = "TutorialGrpID";
            CheckBoxList1.DataBind();
        }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            foreach(ListItem row in CheckBoxList1.Items)
            {
                if (row.Selected)
                {
                    Label1.Text = row.Text.ToString();
                }
            }
        }
    }
}