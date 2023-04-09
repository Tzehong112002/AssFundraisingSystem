using System;
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
    public partial class Profile : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["MYConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("../UserSide/Login.aspx");
            }
            else {

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

                                string username = reader["Username"].ToString();
                                string imgFile = reader["ProfilePic"].ToString();
                                string Name = reader["Name"].ToString();
                                string email = reader["Email"].ToString();
                                string phoneNo = reader["PhoneNo"].ToString();
                                string roles = reader["Roles"].ToString();

                                

                                


                                lblUsername.Text = username;
                                lblName.Text = Name;
                                lblEmail.Text = email;
                                lblContact.Text = phoneNo;
                                lblRoles.Text = roles;
                                imgOrganization.ImageUrl = imgFile;
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

        protected void btnChangePass_Click(object sender, EventArgs e)
        {
            Response.Redirect("changePassword.aspx");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("editProfile.aspx");
        }
    }
}