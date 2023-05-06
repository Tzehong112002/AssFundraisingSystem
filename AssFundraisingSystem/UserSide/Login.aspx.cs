using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using BCrypt.Net;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;
using System.Web;


namespace AssFundraisingSystem.UserSide
{
    public partial class Login : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["MYConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HttpCookie loginCookie = Request.Cookies["LoginCookie"];
                if (loginCookie != null)
                {
                    string username = loginCookie.Values["Username"];
                    string password = loginCookie.Values["Password"];
                    txtUsername.Text = username;
                    txtPassword.Attributes["value"] = password; // set password field without showing the actual password
                    chkRememberMe.Checked = true;
                }
            }

        }

        protected void Unnamed4_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text.Trim();
                string secretKey = "6LfJUNslAAAAADSC7im1g7ZZWAEfqZF1j6Z5yaOY";
                string captchaResponse = Request.Form["g-recaptcha-response"];
                bool captchaValid = VerifyCaptcha(captchaResponse, secretKey);

                if (Page.IsValid && captchaValid)
                {
                    int RowCount;
                    SqlConnection con = new SqlConnection(cs);
                    con.Open();
                    string str = "SELECT * FROM Account WHERE Username=@Username";
                    SqlCommand cmd = new SqlCommand(str, con);
                    cmd.Parameters.AddWithValue("@Username", username);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    RowCount = dt.Rows.Count;

                    if (RowCount > 0)
                    {
                        string hashedPasswordFromDatabase = dt.Rows[0]["Password"].ToString();

                        if (BCrypt.Net.BCrypt.Verify(password, hashedPasswordFromDatabase))
                        {
                            string status = "No";

                            if (dt.Rows[0]["BanStatus"].ToString().Trim() == status)
                            {
                                // Set a cookie if the "Remember Me" checkbox is checked
                                if (chkRememberMe.Checked)
                                {
                                    HttpCookie loginCookie = new HttpCookie("LoginCookie");
                                    loginCookie.Values.Add("Username", username);
                                    loginCookie.Values.Add("Password", password);
                                    loginCookie.Expires = DateTime.Now.AddDays(7);
                                    Response.Cookies.Add(loginCookie);
                                }

                                con.Close();
                                Session["UserID"] = dt.Rows[0]["UserID"].ToString();
                                Response.Redirect("program.aspx");
                            }
                            else
                            {
                                Response.Write("<script>alert('Your account has been banned by the admin.')</script>");
                            }
                        }
                        else
                        {
                            errorMessage.Visible = true;
                            errorMessage.Text = "Invalid Username and Password. Please try again!";
                        }
                    }
                    else
                    {
                        errorMessage.Visible = true;
                        errorMessage.Text = "Invalid Username and Password. Please try again!";
                    }

                    con.Close();
                }
                else
                {
                    errorMessage.Visible = true;
                    errorMessage.Text = "Invalid reCAPTCHA. Please try again!";
                }
            }
            catch (Exception ex)
            {
                errorMessage.Visible = true;
                errorMessage.Text = "An error occurred while processing your request. Please try again later.";
                // Log the exception for debugging purposes
                Console.WriteLine(ex.ToString());
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
