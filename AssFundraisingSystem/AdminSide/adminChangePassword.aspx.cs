using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BCrypt.Net;

namespace AssFundraisingSystem.AdminSide
{
    public partial class adminChangePassword : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["MYConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int adminID;

                if (!int.TryParse(Request.QueryString["UserID"], out adminID))
                {
                    Response.Redirect("adminAccount.aspx");
                    return;
                }

                string query = "SELECT * FROM Account WHERE UserID = @UserID";
                using (SqlConnection connection = new SqlConnection(cs))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", adminID);
                        connection.Open();

                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            ViewState["Password"] = reader["Password"].ToString();
                        }

                        reader.Close(); // Close the data reader before executing the next query
                    }
                }
            }
        }

        protected void btnUpdateAdmin_Click(object sender, EventArgs e)
        {
            int adminID;

            if (!int.TryParse(Request.QueryString["UserID"], out adminID))
            {
                Response.Redirect("adminAccount.aspx");
                return;
            }

            string query = "SELECT * FROM Account WHERE UserID = @UserID";
            using (SqlConnection connection = new SqlConnection(cs))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", adminID);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        string hashedOldPassword = reader["Password"].ToString();
                        reader.Close(); // Close the data reader before executing the next query
                        if (BCrypt.Net.BCrypt.Verify(oldPassword.Text, hashedOldPassword))
                        {
                            string newPassword = NewPassword.Text;
                            string confirmPassword = CfmPassword.Text;
                            if (newPassword.Equals(confirmPassword))
                            {
                                string hashedNewPassword = BCrypt.Net.BCrypt.HashPassword(newPassword);
                                query = "UPDATE Account SET Password = @Password WHERE UserID = @UserID";
                                using (SqlCommand updateCommand = new SqlCommand(query, connection))
                                {
                                    updateCommand.Parameters.AddWithValue("@UserID", adminID);
                                    updateCommand.Parameters.AddWithValue("@Password", hashedNewPassword);

                                    int result = updateCommand.ExecuteNonQuery();

                                    if (result > 0)
                                    {
                                        Response.Write("<script>alert('Password updated successfully.')</script>");
                                        Response.Redirect("adminAccount.aspx");

                                    }
                                    else
                                    {
                                        Response.Write("<script>alert('Failed to update password. Please try again.')</script>");
                                    }
                                }
                            }
                            else
                            {
                                Response.Write("<script>alert('New password and confirm password do not match. Please try again.')</script>");
                            }
                        }
                        else
                        {
                            Response.Write("<script>alert('Old password is incorrect. Please try again.')</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('User ID not found.')</script>");
                    }
                }
            }
        }



        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminAccount.aspx");
        }

    }
}
