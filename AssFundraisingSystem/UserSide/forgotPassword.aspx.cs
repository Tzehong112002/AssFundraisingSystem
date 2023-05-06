using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;

namespace AssFundraisingSystem.UserSide
{
    public partial class forgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string constr = ConfigurationManager.ConnectionStrings["MYConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();

                // Check if the email exists in the database
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Account WHERE Email = @Email", con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            // The email does not exist in the database
                            lblError.Text = "This email address is not registered in our system.";
                            lblError.Visible = true;
                            return;
                        }
                    }
                }

                // Generate a unique reset token
                string resetToken = Guid.NewGuid().ToString();

                // Save the reset token and its expiry date to the database
                //using (SqlCommand cmd = new SqlCommand("UPDATE PasswordReset SET ResetToken = @ResetToken, ResetTokenExpiry = DATEADD(HOUR, 1, GETDATE()) WHERE Email = @Email", con))
                /*using (SqlCommand cmd = new SqlCommand("UPDATE PasswordReset SET ResetToken = @ResetToken, ResetTokenExpiry = DATEADD(HOUR, 1, GETDATE()) WHERE UserID = (SELECT UserID FROM Account WHERE Email = @Email)", con))
                {
                    cmd.Parameters.AddWithValue("@ResetToken", resetToken);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.ExecuteNonQuery();
                }*/

                // Save the reset token and its expiry date to the database
                int userId;
                using (SqlCommand cmd = new SqlCommand("SELECT UserID FROM Account WHERE Email = @Email", con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    userId = (int)cmd.ExecuteScalar();
                }
                if (userId > 0)
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO PasswordReset (UserID, ResetToken, ResetTokenExpiry) VALUES (@UserID, @ResetToken, DATEADD(HOUR, 1, GETDATE()))", con))
                    {
                        cmd.Parameters.AddWithValue("@ResetToken", resetToken);
                        cmd.Parameters.AddWithValue("@UserID", userId);
                        cmd.ExecuteNonQuery();
                    }
                }

                // Send an email to the user with the password reset link
                string fromEmail = ConfigurationManager.AppSettings["FromEmail"];
                string fromPassword = ConfigurationManager.AppSettings["FromPassword"];
                string emailSubject = "Password Reset Requested";
                string emailBody = "Dear user,<br /><br />We received a request to reset the password for your account.<br /><br />" +
                    "To reset your password, please click on the link below:<br /><br />" +
                    "<a href='" + Request.Url.Scheme + "://" + Request.Url.Authority + "/UserSide/resetPassword.aspx?email=" + email + "&token=" + resetToken + "'>Reset Password</a><br /><br />" +
                    "This link is valid for 1 hour from the time it was generated.<br /><br />" +
                    "If you did not request a password reset, please ignore this email.<br /><br />" +
                    "Thank you,<br />Fundraising System Team";
                MailMessage mailMessage = new MailMessage(fromEmail, email, emailSubject, emailBody);
                mailMessage.IsBodyHtml = true;
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(fromEmail, fromPassword);
                smtpClient.EnableSsl = true;
                smtpClient.Send(mailMessage);

                lblSuccess.Text = "An email has been sent to your email address with instructions to reset your password.";
                lblSuccess.Visible = true;



            }
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
