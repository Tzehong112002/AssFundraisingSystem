using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using BCrypt.Net;
using System.Web;

namespace AssFundraisingSystem.UserSide
{
    public partial class OrganizationLogin : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["MYConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                   
                }
            }
            catch (Exception ex)
            {
                errorMessage.Visible = true;
                errorMessage.Text = "An error occurred while processing your request. Please try again later.";
            }
        }

        protected void Unnamed4_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text.Trim();
                string adminRoles = "Admin";
                string organizationRoles = "Organization";
                String Status = "No";

                if (Page.IsValid)
                {
                    string query = "SELECT UserID, Username, Password, Roles ,BanStatus FROM Account WHERE Username = @Username";
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
                                        if (reader["BanStatus"].ToString().Trim() == Status.Trim())
                                        {
                                            Session["UserID"] = userID;

                                         
                                           

                                            reader.Close();
                                            Response.Redirect("../organizationSide/applyProgram.aspx");
                                        }
                                        else
                                        {
                                            Response.Write("<script>alert('Your account has been banned by the admin.')</script>");
                                        }
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
                                    lblMessage.Text = "Invalid Username and Password. Please Try Again!";
                                }
                            }
                            else
                            {
                                lblMessage.Visible = true;
                                lblMessage.Text = "Invalid Username and Password. Please Try Again!";
                            }

                            reader.Close(); // Close the data reader before exiting the method
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage.Visible = true;
                errorMessage.Text = "An error occurred while processing your request. Please try again";

            }
        }
    }
}
