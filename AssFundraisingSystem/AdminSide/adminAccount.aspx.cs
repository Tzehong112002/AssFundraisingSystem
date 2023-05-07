using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace AssFundraisingSystem.AdminSide
{
    public partial class adminAccount : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["MYConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindRepeater();
            }
        }

        private void BindRepeater()
        {

            using (SqlConnection con = new SqlConnection(cs))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Account WHERE Roles = 'Admin'", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            RepeaterAdmin.DataSource = dt;
                            RepeaterAdmin.DataBind();
                        }
                    }
                }
            }
        }

        protected void DeleteUser(object sender, EventArgs e)
        {
            try
            {
                LinkButton btnDecline = (LinkButton)sender;
                string UserID = btnDecline.CommandArgument;

                // Check if the user has any related records before deleting
                using (SqlConnection con = new SqlConnection(cs))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Payment WHERE UserID = @UserID", con))
                    {
                        cmd.Parameters.AddWithValue("@UserID", UserID);
                        con.Open();
                        int count = (int)cmd.ExecuteScalar();
                        con.Close();

                        if (count > 0)
                        {
                            Response.Write("<h1>Sorry, you cannot delete this user because there are related records.</h1>");

                            // Display a hyperlink that allows the user to go back
                            Response.Write("<p><a href='javascript:history.back()'>Go back</a></p>");
                            return;
                        }
                    }
                }

                // If there are no related records, delete the user
                using (SqlConnection con = new SqlConnection(cs))
                {
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM Account WHERE UserID = @UserID", con))
                    {
                        cmd.Parameters.AddWithValue("@UserID", UserID);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }

                this.BindRepeater();
            }
            catch (Exception ex)
            {
                // Display a generic error message
                Response.Write("<center><h1>Sorry, an error occurred while processing your request.</h1></center>");

                // Display a hyperlink that allows the user to go back
                Response.Write("<center><p><a href='javascript:history.back()'>Go back</a></p></center>");

            }
        }


        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddAdmin.aspx");
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