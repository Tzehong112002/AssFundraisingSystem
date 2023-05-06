using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using BCrypt.Net;
using System.Web;


using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;





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
                string secretKey = "6LfJUNslAAAAADSC7im1g7ZZWAEfqZF1j6Z5yaOY";
                string captchaResponse = Request.Form["g-recaptcha-response"];
                bool captchaValid = VerifyCaptcha(captchaResponse, secretKey);

                if (Page.IsValid & captchaValid)
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
                else
                {
                    errorMessage.Visible = true;
                    errorMessage.Text = "Invalid Username and Password. Please try again!";
                }
            }
            catch (Exception ex)
            {
                errorMessage.Visible = true;
                errorMessage.Text = "An error occurred while processing your request. Please try again";

            }
        }

        private bool VerifyCaptcha(string captchaResponse, string secretKey)
        {
            bool result = false;

            try
            {
                string apiUrl = "https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}";
                string requestUri = string.Format(apiUrl, secretKey, captchaResponse);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUri);
                request.Timeout = 5000;
                using (WebResponse response = request.GetResponse())
                {
                    using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
                    {
                        JObject jResponse = JObject.Parse(streamReader.ReadToEnd());
                        bool success = (bool)jResponse.SelectToken("success");
                        result = success;
                    }
                }
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
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
