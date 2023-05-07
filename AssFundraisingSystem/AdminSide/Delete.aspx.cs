using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

namespace AssFundraisingSystem
{
    public partial class Delete : System.Web.UI.Page
    {
        string conStr = ConfigurationManager.ConnectionStrings["MYConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            string delid = Request.QueryString["id"] ?? "";

            string delsql = "DELETE FROM Categories WHERE ID = @Id";

            try
            {
                using (SqlConnection conn = new SqlConnection(conStr))
                {
                    using (SqlCommand cmd = new SqlCommand(delsql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", delid);

                        conn.Open();

                        cmd.ExecuteNonQuery();

                        conn.Close();
                    }
                }

                Response.Redirect("Categories.aspx");
            }
            catch (Exception ex)
            {
                Response.Write("<h1>Sorry, you cannot delete this user because there are related records.</h1>");

                // Display a hyperlink that allows the user to go back
                Response.Write("<p><a href='javascript:history.back()'>Go back</a></p>");
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