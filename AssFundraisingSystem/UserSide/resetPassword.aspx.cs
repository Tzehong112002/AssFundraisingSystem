using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using BCrypt.Net;


namespace AssFundraisingSystem.UserSide
{
    public partial class resetPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check if the reset token and email address are valid
                string resetToken = Request.QueryString["token"];
                string email = Request.QueryString["email"];
                if (string.IsNullOrEmpty(resetToken) || string.IsNullOrEmpty(email))
                {
                    Response.Redirect("~/error.aspx");
                }
                else
                {
                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MYConnectionString"].ConnectionString))
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("SELECT a.*, pr.ResetTokenExpiry FROM Account a INNER JOIN PasswordReset pr ON a.UserID = pr.UserID WHERE a.Email=@Email AND pr.ResetToken=@ResetToken AND pr.ResetTokenExpiry>@CurrentDate", con);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@ResetToken", resetToken);
                        cmd.Parameters.AddWithValue("@CurrentDate", DateTime.Now);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (!reader.HasRows)
                        {
                            Response.Redirect("~/error2.aspx");
                        }
                        reader.Close();
                    }
                }
            }
        }

        protected void submitbtn_Click1(object sender, EventArgs e)
        {
            // Get the email address and reset token from the query string
            string email = Request.QueryString["email"];
            string resetToken = Request.QueryString["token"];

            // Get the new password and confirm password from the textboxes
            string newPassword = txtPassword.Text.Trim();
            string confirmPassword = txtcfmPassword.Text.Trim();

            // Check if the new password and confirm password match
            if (newPassword != confirmPassword)
            {
                lblError.Text = "New password and confirm password do not match.";
                lblError.Visible = true;
                return;
            }

            // Hash the new password using BCrypt
            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(newPassword, salt);

            // Update the user's password in the database
            int userId;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MYConnectionString"].ConnectionString))
            {
                con.Open();

                // Update the password in the Account table
                SqlCommand cmd = new SqlCommand("UPDATE Account SET Password=@Password WHERE Email=@Email; SELECT UserID FROM Account WHERE Email=@Email", con);
                cmd.Parameters.AddWithValue("@Password", hashedPassword);
                cmd.Parameters.AddWithValue("@Email", email);
                userId = (int)cmd.ExecuteScalar();

                // Delete the reset token fields in the PasswordReset table
                cmd = new SqlCommand("DELETE FROM PasswordReset WHERE UserID=@UserID", con);
                cmd.Parameters.AddWithValue("@UserID", userId);
                cmd.ExecuteNonQuery();
            }



            // Send an email to the user to confirm the password reset
            try {
                // Set up the email message
                string fromEmail = ConfigurationManager.AppSettings["FromEmail"];
                string fromPassword = ConfigurationManager.AppSettings["FromPassword"];
                string emailSubject = "Password Reset Confirmation";
                string emailBody = "Dear user,<br /><br />Your password has been successfully reset.<br /><br />" +
                    "If you did not initiate this password reset request, please contact us immediately.<br /><br />" +
                    "Thank you,<br />Fundraising System Team";

                MailMessage mailMessage = new MailMessage(fromEmail, email, emailSubject, emailBody);
                mailMessage.IsBodyHtml = true;

                // Set up the SMTP client
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Host = ConfigurationManager.AppSettings["SMTPServer"];
                smtpClient.Port = int.Parse(ConfigurationManager.AppSettings["SMTPPort"]);
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(fromEmail, fromPassword);
                smtpClient.EnableSsl = true;

                // Send the email
                smtpClient.Send(mailMessage);

                // Show success message
                lblSuccess.Text = "Your password has been successfully reset. An email has been sent to your email address with confirmation.";
                lblSuccess.Visible = true;
            }
            catch (Exception ex)
            {
                // Show error message
                lblError.Text = "An error occurred while sending the email. Please try again later.";
                lblError.Visible = true;
            }

            string redirectUrl = "Login.aspx"; // Replace with your login page URL
            Response.Write("<script type='text/javascript'>");
            Response.Write("setTimeout(function(){ window.location.href = '" + redirectUrl + "'; }, 5000);"); // 5000 ms = 5 seconds
            Response.Write("</script>");



        }
    }
}
