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
using System.Drawing;

namespace AdaptiveLearningSystem
{
    public partial class CourseList : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(@"Data Source=ASUS\SQLSERVER;Initial Catalog=fyp;Integrated Security=True");
            DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("prc_course_list", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;

            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }

        protected void txtSearchName_TextChanged(object sender, EventArgs e)
        {
            
            DataTable tempdr = new DataTable();
            tempdr = dt.Clone();
            if (String.IsNullOrEmpty(txtSearchName.Text.Trim()))
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();

            }
            else
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (row["CourseName"].ToString().ToLower().Contains(txtSearchName.Text.Trim().ToLower()))
                    {
                        tempdr.ImportRow(row);
                    }

                }
                

                GridView1.DataSource = tempdr;
                GridView1.DataBind();
            }
        }

        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";
            }
        }


        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowIndex == GridView1.SelectedIndex)
                {
                    row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                    row.ToolTip = string.Empty;
                    Response.Redirect("CourseDetails.aspx?course="+row.Cells[1].Text.ToString());
                    
                }
                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    row.ToolTip = "Click to select this row.";
                }
            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        { 
            ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Password Changed Successfully'); window.location.href='CourseList.aspx';", true);
        }

        protected void ProfilesLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("LecProfile.aspx");
        }

        protected void HomeLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("LecHome.aspx");
        }
    }
}