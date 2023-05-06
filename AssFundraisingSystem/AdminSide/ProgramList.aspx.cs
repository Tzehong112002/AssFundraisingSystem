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
    public partial class ProgramList : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["MYConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack) {
                this.BindRepeater();
            }
                


        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("addProgram.aspx");
        }

        private void BindRepeater()
        {

            using (SqlConnection con = new SqlConnection(cs))
            {
                using (SqlCommand cmd = new SqlCommand("Select * from Event WHERE EventStatus='Approved' AND EventEndDate >= CURRENT_TIMESTAMP", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            RepeaterEvent.DataSource = dt;
                            RepeaterEvent.DataBind();
                        }
                    }
                }
            }
        }

        protected void DeleteCustomer(object sender, EventArgs e)
        {

            LinkButton lnkDelete = (LinkButton)sender;
            string eventID = lnkDelete.CommandArgument;



            using (SqlConnection con = new SqlConnection(cs))
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Event WHERE EventID = @EventID", con))
                {
                    cmd.Parameters.AddWithValue("@EventID", eventID);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            this.BindRepeater();
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