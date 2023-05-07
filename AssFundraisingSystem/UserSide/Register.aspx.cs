﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BCrypt.Net;

namespace AssFundraisingSystem.UserSide
{
    public partial class Register : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["MYConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed7_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (checkExist() == true)
                {
                    string name = txtName.Text;
                    string username = txtusername.Text.Trim();
                    string email = txtEmail.Text;
                    string password = txtPassword.Text.Trim();
                    string confirmPassword = txtConfirmPassword.Text.Trim();
                    String StatusUser = "No";

                    if (password == confirmPassword)
                    {
                        if (username.Length < 6)
                        {
                            Response.Write("<script>alert('Username must be at least 6 characters long.')</script>");
                            return;
                        }

                        string roles = "User";
                        string image = "Img/profile.png";

                        string salt = BCrypt.Net.BCrypt.GenerateSalt();
                        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);

                        string sql = "INSERT INTO Account(Name, Email, Password, Roles, ProfilePic ,Username,BanStatus) VALUES (@Name, @Email, @Password, @Roles, @ProfilePic ,@Username,@BanStatus)";
                        SqlConnection con = new SqlConnection(cs);
                        SqlCommand cmd = new SqlCommand(sql, con);

                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", hashedPassword);
                        cmd.Parameters.AddWithValue("@Roles", roles);
                        cmd.Parameters.AddWithValue("@ProfilePic", image);
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@BanStatus", StatusUser);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        Response.Write("<script>alert('Thanks for your registration, our admin will approve your account as soon as possible :)')</script>");
                        Server.Transfer("Login.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('The password and confirm password must match. Please try again.')</script>");
                    }

                }
            }
        }

        protected void ValidateUsername(object source, ServerValidateEventArgs args)
        {
            string username = args.Value.Trim();
            if (username.Length < 6)
            {
                args.IsValid = false;
                usernameValidator.ErrorMessage = "Username must be at least 6 characters long";
                return;
            }

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Account WHERE Username = @Username", connection);
                command.Parameters.AddWithValue("@Username", username);
                int count = (int)command.ExecuteScalar();
                if (count > 0)
                {
                    args.IsValid = false;
                    usernameValidator.ErrorMessage = "Username already exists";
                }
            }
        }



        private Boolean checkExist()
        {
            SqlConnection con = new SqlConnection(cs);
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT Username FROM Account WHERE Username='" + txtusername.Text + "'", con);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                if (dr[0].ToString() == txtusername.Text)
                {
                    con.Close();
                    Response.Write("<script>alert('This username is already taken. Please choose another one.')</script>");
                    return false;
                }
            }
            con.Close();
            return true;
        }

        //void Page_Error()
        //{
        //    // Get the exception object
        //    Exception ex = Server.GetLastError();

        //    // Clear the error so it doesn't propagate further
        //    Server.ClearError();

        //    // Display a message indicating that there might be an error
        //    Response.Write("<h1>Sorry, an error occurred while processing your request.</h1>");

        //    // Display a hyperlink that allows the user to go back
        //    Response.Write("<p><a href='javascript:history.back()' style='color:red; text-decoration:none;'>Go back</a></p>");
        //}

    }
}
