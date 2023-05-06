using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AssFundraisingSystem.organizationSide
{
    public partial class ProgramApplyHistory : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["MYConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("../UserSide/OrganizationLogin.aspx");

            }
            else
            {
                if (!this.IsPostBack)
                {
                    this.BindRepeater();
                }
            }
        }

        private void BindRepeater()
        {
            string UserID = Session["UserID"].ToString().Trim();
            using (SqlConnection con = new SqlConnection(cs))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Event.*, Account.Name, Categories.CategoryTitle FROM Event INNER JOIN Account ON Event.UserID = Account.UserID INNER JOIN Categories ON Event.CategoryID = Categories.ID WHERE Event.UserID = @UserID;", con))
                {
                    cmd.Parameters.AddWithValue("@UserID", UserID);
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            RepeaterHistory.DataSource = dt;
                            RepeaterHistory.DataBind();
                        }
                    }
                }
            }
        }

        void Page_Error()
        {
            // Get the exception object
            Exception ex = Server.GetLastError();

            // Clear the error so it doesn't propagate further
            Server.ClearError();

            // Display a message indicating that there might be an error
            Response.Write("<h1>Sorry, an error occurred while processing your request.</h1>");

            // Display a hyperlink that allows the user to go back
            Response.Write("<p><a href='javascript:history.back()' style='color:red; text-decoration:none;'>Go back</a></p>");
        }

    }
}
