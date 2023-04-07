using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Security.Cryptography;

namespace AssFundraisingSystem.UserSide
{
    public partial class changePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {

                Response.Redirect("../UserSide/Login.aspx");
            }

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string oldPassword = TextBox1.Text.Trim();
            string newPassword = TextBox2.Text.Trim();
            string confirmPassword = TextBox3.Text.Trim();

            if (newPassword != confirmPassword)
            {
                // display error message to user that passwords do not match
                return;
            }

            string cs = ConfigurationManager.ConnectionStrings["MYConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                string query = "SELECT Password FROM Account WHERE UserId = @UserId";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@UserId", Session["UserId"].ToString());
                string savedPasswordHash = (string)cmd.ExecuteScalar();

                if (BCrypt.Net.BCrypt.Verify(oldPassword, savedPasswordHash))
                {
                    // password entered by user matches saved password, so update the password
                    string newPasswordHash = BCrypt.Net.BCrypt.HashPassword(newPassword);
                    query = "UPDATE Account SET Password = @Password WHERE UserId = @UserId";
                    cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Password", newPasswordHash);
                    cmd.Parameters.AddWithValue("@UserId", Session["UserId"].ToString());
                    cmd.ExecuteNonQuery();

                    Response.Redirect("Profile.aspx");
                    // display success message to user
                }
                else
                {
                    // password entered by user does not match saved password, so display error message
                }
            }
        }


        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Profile.aspx");
        }
    }
}