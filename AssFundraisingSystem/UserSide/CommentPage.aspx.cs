﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AssFundraisingSystem.UserSide
{
    public partial class CommentPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("../UserSide/Login.aspx");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int eventID = Convert.ToInt32(Request.QueryString["EventID"] ?? Session["EventID"]);


            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            string query = "INSERT INTO Comment (EventID, UserID, CommentContent, DateCommented) VALUES (@EventID, @UserID, @CommentText, @DateCommented)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EventID", eventID);
                    command.Parameters.AddWithValue("@UserID", Session["UserID"]);
                    command.Parameters.AddWithValue("@CommentText", txtComment.Text);
                    command.Parameters.AddWithValue("@DateCommented", DateTime.Now);
                    connection.Open();
                    command.ExecuteNonQuery();
                }

            }
            txtComment.Text = "";
            Response.Write("<script>alert('Comment Submit Successfully!')</script>");
            Response.Redirect("historyPayment.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("historyPayment.aspx");
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