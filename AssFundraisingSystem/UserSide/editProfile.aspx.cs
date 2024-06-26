﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace AssFundraisingSystem.UserSide
{
    public partial class editProfile : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["MYConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Session["UserID"] == null)
                {

                    Response.Redirect("../UserSide/Login.aspx");
                }
                else
                {

                    string query = "SELECT * FROM Account WHERE UserID = @UserId";
                    String UserID = Session["UserID"].ToString().Trim();

                    using (SqlConnection connection = new SqlConnection(cs))
                    {
                        connection.Open();

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@UserId", UserID);

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    reader.Read();


                                    string Name = reader["Name"].ToString();
                                    string email = reader["Email"].ToString();
                                    string phoneNo = reader["PhoneNo"].ToString();
                                    string roles = reader["Roles"].ToString();
                                    string gender = reader["Gender"].ToString();
                                    DateTime? dateOfBirth = reader.IsDBNull(reader.GetOrdinal("DateOfBirth")) ? null : (DateTime?)reader.GetDateTime(reader.GetOrdinal("DateOfBirth"));





                                    txtName.Text = Name;
                                    rblGender.Text = Name;
                                    txtEmail.Text = email;
                                    txtContactNumber.Text = phoneNo;


                                    if (gender != null) rblGender.SelectedValue = gender;
                                    if (dateOfBirth.HasValue) calendarBirth.SelectedDate = dateOfBirth.Value;


                                }
                                else
                                {

                                    /*Response.Redirect("~/ErrorPage.aspx");*/
                                }
                            }
                        }
                    }
                }

            }

        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Profile.aspx");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

            string name = txtName.Text;
            string gender = rblGender.SelectedValue;
            string email = txtEmail.Text;
            string contactNumber = txtContactNumber.Text;
            DateTime birthDate = calendarBirth.SelectedDate;

            string pathImg = "";
            string fileName = "ProfilePicUser";
            string fileextension = "jpg";
            int userID = Convert.ToInt32(Session["userID"]);

            if (fuProfilePic.HasFile)
            {
                String pictureName = fuProfilePic.FileName;
                fileextension = Path.GetExtension(fuProfilePic.FileName);
                fuProfilePic.PostedFile.SaveAs(Server.MapPath("../UserSide/Img/" + fileName + "/" + userID + fileextension));
                pathImg = "../UserSide/Img/" + fileName + "/" + userID + fileextension;


            }


            if (calendarBirth.SelectedDate > DateTime.Today)
            {
                ErrorMessage("Birth date cannot be after the current date.");
                return;
            }

            string updateQuery = "UPDATE account SET Name = @name, Gender = @gender, Email = @email, ProfilePic =@PathName, "
                + "PhoneNo = @contactNumber, DateOfBirth = @birthDate WHERE UserID = @userID";

            using (SqlConnection connection = new SqlConnection(cs))
            using (SqlCommand command = new SqlCommand(updateQuery, connection))
            {

                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@gender", gender);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@PathName", pathImg);

                command.Parameters.AddWithValue("@contactNumber", contactNumber);
                command.Parameters.AddWithValue("@birthDate", birthDate);
                command.Parameters.AddWithValue("@userID", userID);

                connection.Open();
                command.ExecuteNonQuery();

                connection.Close();



                Response.Redirect("../UserSide/Profile.aspx");

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

        protected void ErrorMessage(string msg)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ErrorMessage", "alert('" + msg + "');", true);
        }


    }
}