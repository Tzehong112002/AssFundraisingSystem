using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using BCrypt.Net;

namespace AssFundraisingSystem.UserSide
{
    public partial class Login : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["MYConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed4_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (Page.IsValid)
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
                        con.Close();
                        Session["UserID"] = dt.Rows[0]["UserID"].ToString();
                        Response.Redirect("program.aspx");
                    }
                    else
                    {
                        lblMessage.Visible = true;
                        lblMessage.Text = "Invalid Username and Password. Please Try Again!";
                    }
                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "Invalid Username and Password. Please Try Again!";
                }

                con.Close();
            }
        }
    }
}
