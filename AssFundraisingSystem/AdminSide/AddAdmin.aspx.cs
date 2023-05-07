using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace AssFundraisingSystem.AdminSide
{
    public partial class AddAdmin : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["MYConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            // Validate password and confirm password
            if (TextBox2.Text != TextBox3.Text)
            {
                Response.Write("<script>alert('Passwords do not match. Please try again.');</script>");
                return;
            }

            // Hash password using BCrypt
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(TextBox2.Text);

            // Check if username already exists in the database
            string checkQuery = "SELECT COUNT(*) FROM Account WHERE Username = @Username";
            int count;
            using (SqlConnection connection = new SqlConnection(cs))
            {
                using (SqlCommand command = new SqlCommand(checkQuery, connection))
                {
                    command.Parameters.AddWithValue("@Username", TextBox4.Text);

                    connection.Open();
                    count = (int)command.ExecuteScalar();
                }
            }

            if (count > 0)
            {
                Response.Write("<script>alert('Username already exists. Please choose another one.');</script>");
                return;
            }

            // Insert data into database
            string insertQuery = "INSERT INTO Account (Name, Email, Password, PhoneNo, Roles, ProfilePic, Gender, DateOfBirth, Username, StatusBecomeOrganization, submitICFront, submitICBack, submitCompanyName) VALUES (@Name, @Email, @Password, @PhoneNo, @Roles, @ProfilePic, @Gender, @DateOfBirth, @Username, @StatusBecomeOrganization, @submitICFront, @submitICBack, @submitCompanyName)";

            String Name = TextBox4.Text;
            String pictureName = FileUpload1.FileName;
            string pathImg = "unknown";
            string fileName = "AdminPic";
            string fileextension = "jpg";

            if (FileUpload1.HasFile)
            {              

                fileextension = Path.GetExtension(FileUpload1.FileName);
                FileUpload1.PostedFile.SaveAs(Server.MapPath("../AdminSide/Img/" + fileName + "/" + Name + fileextension));
                pathImg = "../AdminSide/Img/" + fileName + "/" + Name + fileextension;


            }


            if (string.IsNullOrEmpty(TextBox1.Text) || string.IsNullOrEmpty(TextBox2.Text) || string.IsNullOrEmpty(TextBox3.Text) || string.IsNullOrEmpty(TextBox4.Text) || string.IsNullOrEmpty(TextBox5.Text) || string.IsNullOrEmpty(FileUpload1.PostedFile.FileName))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('Please fill out all fields.');", true);
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(cs))
                {
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Name", TextBox1.Text);
                        command.Parameters.AddWithValue("@Email", TextBox1.Text);
                        command.Parameters.AddWithValue("@Password", hashedPassword);
                        command.Parameters.AddWithValue("@PhoneNo", TextBox5.Text);
                        command.Parameters.AddWithValue("@Roles", "Admin");
                        command.Parameters.AddWithValue("@ProfilePic", pathImg);
                        command.Parameters.AddWithValue("@Gender", "");
                        command.Parameters.AddWithValue("@DateOfBirth", DBNull.Value);
                        command.Parameters.AddWithValue("@Username", TextBox4.Text);
                        command.Parameters.AddWithValue("@StatusBecomeOrganization", DBNull.Value);
                        command.Parameters.AddWithValue("@submitICFront", DBNull.Value);
                        command.Parameters.AddWithValue("@submitICBack", DBNull.Value);
                        command.Parameters.AddWithValue("@submitCompanyName", DBNull.Value);

                        connection.Open();
                        int result = command.ExecuteNonQuery();
                        if (result > 0)
                        {
                            Response.Redirect("adminAccount.aspx");
                        }
                        else
                        {
                            Response.Write("<script>alert('Failed to add admin.');</script>");
                        }
                    }
                }
            }

        }



        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminAccount.aspx");
        }

        void Page_Error()
        {
            // Get the exception object
            Exception ex = Server.GetLastError();

            // Clear the error so it doesn't propagate further
            Server.ClearError();

            // Display a message indicating that there might be an error
            Response.Write("<div style='text-align: center'><h1>Sorry, an error occurred while processing your request.</h1>");

            // Display a hyperlink that allows the user to go back
            Response.Write("<p><a href='javascript:history.back()' style='color:red; text-decoration:none;'>Go back</a></p></div>");
        }

    }
}
