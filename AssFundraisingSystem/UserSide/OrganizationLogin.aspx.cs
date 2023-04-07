using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AssFundraisingSystem.UserSide
{
    public partial class OrganizationLogin : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["MYConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed4_Click(object sender, EventArgs e)
        {

            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string adminRoles = "Admin";
            string organizationRoles = "Organization";

            if (Page.IsValid)
            {

                int RowCount;
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                string str = "SELECT * FROM Account";
                SqlCommand cmd = new SqlCommand(str);
                SqlDataAdapter sda = new SqlDataAdapter(cmd.CommandText, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                RowCount = dt.Rows.Count;
                for (int i = 0; i < RowCount; i++)
                {
                    string Username = dt.Rows[i]["Username"].ToString();
                    string Password = dt.Rows[i]["Password"].ToString();
                    string Roles = dt.Rows[i]["Roles"].ToString();
                    String Userid = dt.Rows[i]["UserID"].ToString();


                    if (Username == username && Password == password && Roles == organizationRoles)
                    {
                        Session["UserID"] = Userid;

                        con.Close();

                        Response.Redirect("../organizationSide/applyProgram.aspx");


                    }
                    else if (Username == username && Password == password && Roles == adminRoles)
                    {
                        Session["Username"] = username;
                        con.Close();

                        Response.Redirect("../AdminSide/dashboard.aspx");

                    }
                    else
                    {

                        lblMessage.Visible = true;
                        lblMessage.Text = "Invalid Email and Password.Please Try Again!";

                    }




                }
            }

        }
    }
}