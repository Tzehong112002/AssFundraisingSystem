﻿using System;
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
    public partial class approveEvent : System.Web.UI.Page
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
                String status = "Not Approved";
                /*retrieve only show the event that select by one user*/
                using (SqlCommand cmd = new SqlCommand("SELECT Event.*, Account.Name FROM Event INNER JOIN Account ON Event.UserID = Account.UserID WHERE Event.EventStatus = @EventStatus;", con))
                {

                    cmd.Parameters.AddWithValue("@EventStatus", status);
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            RepeaterProgramApply.DataSource = dt;
                            RepeaterProgramApply.DataBind();
                        }
                    }
                }
            }
        }

        protected void UpdateEvent(object sender, EventArgs e)
        {

            LinkButton btnApprove = (LinkButton)sender;
            string eventID = btnApprove.CommandArgument;



            using (SqlConnection con = new SqlConnection(cs))
            {
                String NewEventStatus = "Approved";
                using (SqlCommand cmd = new SqlCommand("UPDATE [dbo].[Event] SET [EventStatus] = @NewEventStatus WHERE [EventID] = @EventID", con))
                {
                    cmd.Parameters.AddWithValue("@NewEventStatus", NewEventStatus);
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
            Response.Write("<div style='text-align: center'><h1>Sorry, an error occurred while processing your request.</h1>");

            // Display a hyperlink that allows the user to go back
            Response.Write("<p><a href='javascript:history.back()' style='color:red; text-decoration:none;'>Go back</a></p></div>");
        }

    }
}