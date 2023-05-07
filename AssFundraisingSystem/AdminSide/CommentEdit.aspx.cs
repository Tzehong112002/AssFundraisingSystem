using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace AssFundraisingSystem.AdminSide
{
    public partial class CommentEdit : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["MYConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            string commentid = Request.QueryString["CommentID"];
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("SELECT * FROM Comment WHERE CommentID = '" + commentid + "'", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                txtComment.Text = dr["CommentContent"].ToString();
                Calendar1.SelectedDate = Convert.ToDateTime(dr["DateCommented"]);
            }

            dr.Close();
            con.Close();
        }


        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int commentId = Int32.Parse(Request.QueryString["CommentID"]);
                int EventId = Int32.Parse(Request.QueryString["EventID"]);
                string commentContent = txtComment.Text;
                DateTime dateCommented = Calendar1.SelectedDate;


                using (SqlConnection con = new SqlConnection(cs))
                {
                    string sql = "UPDATE Comment SET CommentContent = @CommentContent, DateCommented = @DateCommented WHERE CommentID = @CommentID";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@CommentID", commentId);
                        cmd.Parameters.AddWithValue("@CommentContent", commentContent);
                        cmd.Parameters.AddWithValue("@DateCommented", dateCommented);

                        con.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        con.Close();

                        if (rowsAffected > 0)
                        {
                            Response.Write("<script>alert('Comment updated successfully!')</script>");
                            Response.Redirect("ProgramList.aspx?EventID=" + EventId);
                        }
                        else
                        {
                            Response.Write("<script>alert('No rows were updated. Please try again.')</script>");
                        }
                    }
                }
            }
        }




        protected void btnCancel_Click(object sender, EventArgs e)
        {
            int eventid = Int32.Parse(Request.QueryString["EventID"]);
            Response.Redirect("CommentManage.aspx?EventId=" + eventid);
        }

        void Page_Error()
        {
            // Get the exception object
            Exception ex = Server.GetLastError();

            // Clear the error so it doesn't propagate further
            Server.ClearError();

            // Display a message indicating that there might be an error
            Response.Write("<div style='text-align: center'><h1>Sorry, an error occurred while processing your request.</h1>");

            // Display a hyperlink that allows the user to go back
            Response.Write("<p><a href='javascript:history.back()' style='color:red; text-decoration:none;'>Go back</a></p></div>");
        }

    }
}