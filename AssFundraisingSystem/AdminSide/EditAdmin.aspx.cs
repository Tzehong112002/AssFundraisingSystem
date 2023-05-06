using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Org.BouncyCastle.Asn1.X509;
using System.Runtime.InteropServices.ComTypes;

namespace AssFundraisingSystem.AdminSide
{
    public partial class EditAdmin : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MYConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                int adminID;
                if (!int.TryParse(Request.QueryString["UserID"], out adminID))
                {
                    Response.Redirect("adminAccount.aspx");
                    return;
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Account WHERE UserID = @UserID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", adminID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                TextBox1.Text = reader["Name"].ToString();
                                TextBox5.Text = reader["PhoneNo"].ToString();
                                Passvalue.Text = reader["Username"].ToString();
                            }
                            else
                            {
                                Response.Redirect("adminAccount.aspx");
                                return;
                            }
                        }
                    }
                }
            }

                
            
        }

       

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminAccount.aspx");
        }

        protected void btnUpdateAdmin_Click(object sender, EventArgs e)
        {
            
                int adminID;
                if (!int.TryParse(Request.QueryString["UserID"], out adminID))
                {
                    Response.Redirect("adminAccount.aspx");
                    return;
                }

                string name = TextBox1.Text.Trim();
                string phoneNo = TextBox5.Text.Trim();
                string pathImg = "unknown";
                string fileName = "AdminPic";
                string fileextension = "jpg";
                String Name = Passvalue.Text;

                if (FileUpload1.HasFile)
                {

                    fileextension = Path.GetExtension(FileUpload1.FileName);
                    FileUpload1.PostedFile.SaveAs(Server.MapPath("../AdminSide/Img/" + fileName + "/" + Name + fileextension));
                    pathImg = "../AdminSide/Img/" + fileName + "/" + Name + fileextension;


                }


            if (string.IsNullOrEmpty(TextBox1.Text) || string.IsNullOrEmpty(TextBox5.Text) || string.IsNullOrEmpty(FileUpload1.PostedFile.FileName))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('Please fill out all fields.');", true);
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Account SET Name = @Name, PhoneNo = @PhoneNo ,ProfilePic =@pathImg WHERE UserID = @UserID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@PhoneNo", phoneNo);
                        command.Parameters.AddWithValue("@pathImg", pathImg);
                        command.Parameters.AddWithValue("@UserID", adminID);

                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            Response.Redirect("adminAccount.aspx");
                            // Display success message
                            //message.InnerHtml = "Admin updated successfully.";
                            //message.Style.Add("display", "block");
                        }
                        else
                        {
                            // Display error message
                            //message.InnerHtml = "Failed to update admin.";
                            //message.Style.Add("display", "block");
                        }
                    }
                }
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
