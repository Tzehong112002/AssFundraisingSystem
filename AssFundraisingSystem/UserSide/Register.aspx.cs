﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


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
                if (checkExist() == true) {
                    string name = txtName.Text;
                    string username = txtusername.Text.Trim();
                    string email = txtEmail.Text;
                    string password = txtPassword.Text.Trim();
                    string roles = "User";
                    string image = "Img/profile.png";


                    string sql = "INSERT INTO Account(Name, Email, Password, Roles, ProfilePic ,Username) VALUES (@Name, @Email, @Password, @Roles, @ProfilePic ,@Username)";
                    SqlConnection con = new SqlConnection(cs);
                    SqlCommand cmd = new SqlCommand(sql, con);


                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@Roles", roles);
                    cmd.Parameters.AddWithValue("@ProfilePic", image);
                    cmd.Parameters.AddWithValue("@Username", username);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    Response.Write("<script>alert('Thanks for your registration, our admin will approve your account as soon as possible :)')</script>");
                    Server.Transfer("Login.aspx");

                }
                


            }
            else
            {
                
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
                    return false;
                }


            }
            con.Close();
            return true;



        }
    }


}