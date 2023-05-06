using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AssFundraisingSystem.UserSide
{
    public partial class Payment : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["MYConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                    // Get the UserID from the Session
                    int userID = Convert.ToInt32(Session["UserID"]);

                    // Fetch the data from the database using the UserID         
                    using (SqlConnection con = new SqlConnection(cs))
                    {
                        SqlCommand cmd = new SqlCommand("SELECT * FROM Account WHERE UserID=@UserID", con);
                        cmd.Parameters.AddWithValue("@UserID", userID);
                        con.Open();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                // Set the values of the textboxes
                                txtName.Text = rdr["Name"].ToString();
                                txtEmail.Text = rdr["Email"].ToString();
                                txtContact.Text = rdr["PhoneNo"].ToString();
                            }
                        }
                    }

                

            }
        }


        protected void Pay_Click(object sender, EventArgs e)
        {
            //Create a new ID
            string donateID = "D" + Guid.NewGuid().ToString().Substring(0, Guid.NewGuid().ToString().IndexOf("-"));

            string name = txtName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string ic = txtIC.Text.Trim();
            string contact = txtContact.Text.Trim();
            string amount = txtAmount.Text.Trim();
            string paymentStatus = "Unpaid";
            string userID = Session["UserID"].ToString();
            //string eventID = Request.QueryString["EventID"];

            string sql = "INSERT INTO Payment(PaymentID, Name, Email, IC, ContactNumber, Amount, PaymentStatus, UserID) VALUES (@PaymentID, @Name, @Email, @Ic, @Contact, @Amount, @PaymentStatus, @UserID)";

            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@PaymentID", donateID);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Ic", ic);
            cmd.Parameters.AddWithValue("@Contact", contact);
            cmd.Parameters.AddWithValue("@Amount", amount);
            cmd.Parameters.AddWithValue("@PaymentStatus", paymentStatus);
            cmd.Parameters.AddWithValue("@UserID", userID);
            //cmd.Parameters.AddWithValue("@EventID", eventID);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            Session["totalAmt"] = amount;
            Session["DonateID"] = donateID;
            Response.Write("<script>alert('Thanks for your Donation')</script>");
            Response.Redirect("donationPayment.aspx");

        }

        //void Page_Error()
        //{
        //    // Get the exception object
        //    Exception ex = Server.GetLastError();

        //    // Clear the error so it doesn't propagate further
        //    Server.ClearError();

        //    // Display a message indicating that there might be an error
        //    Response.Write("<h1>Sorry, an error occurred while processing your request.</h1>");

        //    // Display a hyperlink that allows the user to go back
        //    Response.Write("<p><a href='javascript:history.back()' style='color:red; text-decoration:none;'>Go back</a></p>");
        //}

    }
}