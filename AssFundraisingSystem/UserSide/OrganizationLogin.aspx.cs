using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using BCrypt.Net;

namespace AssFundraisingSystem.UserSide
{
    public partial class OrganizationLogin : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["MYConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Unnamed4_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string adminRoles = "Admin";
            string organizationRoles = "Organization";

            if (Page.IsValid)
            {
                string query = "SELECT UserID, Username, Password, Roles FROM Account WHERE Username = @Username";
                using (SqlConnection connection = new SqlConnection(cs))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        connection.Open();

                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            string hashedPassword = reader["Password"].ToString();
                            string roles = reader["Roles"].ToString();
                            int userID = Convert.ToInt32(reader["UserID"]);

                            if (BCrypt.Net.BCrypt.Verify(password, hashedPassword))
                            {
                                if (roles == organizationRoles)
                                {
                                    Session["UserID"] = userID;
                                    reader.Close();
                                    Response.Redirect("../organizationSide/applyProgram.aspx");
                                }
                                else if (roles == adminRoles)
                                {
                                    Session["Username"] = username;
                                    reader.Close();
                                    Response.Redirect("../AdminSide/dashboard.aspx");
                                }
                            }
                            else
                            {
                                lblMessage.Visible = true;
                                lblMessage.Text = "Invalid Email and Password. Please Try Again!";
                            }
                        }
                        else
                        {
                            lblMessage.Visible = true;
                            lblMessage.Text = "Invalid Email and Password. Please Try Again!";
                        }

                        reader.Close(); // Close the data reader before exiting the method
                    }
                }
            }
        }
    }
}

