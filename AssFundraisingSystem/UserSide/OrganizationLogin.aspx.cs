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
            if (!IsPostBack)
            {
                if (Request.Cookies["AdminUsername"] != null && Request.Cookies["AdminPassword"] != null)
                {
                    txtUsername.Text = Request.Cookies["AdminUsername"].Value;
                    txtPassword.Attributes["value"] = Request.Cookies["AdminPassword"].Value;
                    chkRememberMe.Checked = true;
                }
            }
        }

        protected void Unnamed4_Click(object sender, EventArgs e)
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

                                        // Remember me functionality
                                        if (chkRememberMe.Checked)
                                        {
                                            HttpCookie cookieAdminUsername = new HttpCookie("AdminUsername", username);
                                            HttpCookie cookieAdminPassword = new HttpCookie("AdminPassword", password);
                                            cookieAdminUsername.Expires = DateTime.Now.AddDays(7);
                                            cookieAdminPassword.Expires = DateTime.Now.AddDays(7);
                                            Response.Cookies.Add(cookieAdminUsername);
                                            Response.Cookies.Add(cookieAdminPassword);
                                        }
                                        else
                                        {
                                            Response.Cookies["Username"].Expires = DateTime.Now.AddDays(-1);
                                            Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);
                                        }

                                        reader.Close();
                                        Response.Redirect("../organizationSide/applyProgram.aspx");
                                    }
                                    else
                                    {
                                        Response.Write("<script>alert('Ur accounr been ban by admin'+)</script>");
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
    }

}


