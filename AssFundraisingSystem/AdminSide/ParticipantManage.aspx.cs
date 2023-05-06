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
    public partial class ParticipantManage : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["MYConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindRepeaterParticipant();
            }

        }

        private void BindRepeaterParticipant()
        {
            int EventID = Convert.ToInt32(Request.QueryString["EventID"] ?? Session["EventID"]);

            using (SqlConnection con = new SqlConnection(cs))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT p.PaymentID, a.ProfilePic, a.Username, a.Name, 'RM ' + CONVERT(varchar(10), p.Amount) AS Amount " + "FROM Account a INNER JOIN Payment p ON a.UserID = p.UserID " + "WHERE p.EventID = @EventID", con))
                {
                    cmd.Parameters.AddWithValue("@EventID", EventID);
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

        protected void btnEditParticipant_Click(object sender, EventArgs e)
        {
            Response.Redirect("ParticipantEdit.aspx");
        }

        protected void btnDeleteParticipant_Click(object sender, EventArgs e)
        {
            try
            {
                Button btnDelParticipant = (Button)sender;
                string paymentID = btnDelParticipant.CommandArgument;

                using (SqlConnection con = new SqlConnection(cs))
                {
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM Payment WHERE PaymentID = @PaymentID", con))
                    {
                        cmd.Parameters.AddWithValue("@PaymentID", paymentID);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }

                this.BindRepeaterParticipant();
            }
            catch (Exception ex)
            {
                Response.Write("<h1>Sorry, an error occurred while processing your request.</h1>");
                Response.Write("<p>Please check if the participant has any related records before deleting.</p>");
                Response.Write("<p><a href='javascript:history.back()' style='color:red; text-decoration:none;'>Go back</a></p>");
            }
        }




        /* void Page_Error()
         {
             // Get the exception object
             Exception ex = Server.GetLastError();

             // Clear the error so it doesn't propagate further
             Server.ClearError();

             // Display a message indicating that there might be an error
             Response.Write("<h1>Sorry, an error occurred while processing your request.</h1>");

             // Display a hyperlink that allows the user to go back
             Response.Write("<p><a href='javascript:history.back()' style='color:red; text-decoration:none;'>Go back</a></p>");
         }*/

    }


}