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


        protected void Unnamed7_Click(object sender, EventArgs e)
        {
            int userID = Convert.ToInt32(Session["UserID"]);
            int eventID = Convert.ToInt32(Request.QueryString["EventID"]);

            string name = txtName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string ic = txtIC.Text.Trim();
            string contact = txtContact.Text.Trim();
            string amount = txtAmount.Text.Trim();

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Payment(Name, Email, IC, ContactNumber, Amount, UserID, EventID) VALUES (@Name, @Email, @Ic, @Contact, @Amount, @UserID, @EventID)", con);

                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Ic", ic);
                cmd.Parameters.AddWithValue("@Contact", contact);
                cmd.Parameters.AddWithValue("@Amount", amount);
                cmd.Parameters.AddWithValue("@UserID", userID);
                cmd.Parameters.AddWithValue("@EventID", eventID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            Response.Write("<script>alert('Thanks for your Donation')</script>");
            Server.Transfer("program.aspx");
        }
    }
}