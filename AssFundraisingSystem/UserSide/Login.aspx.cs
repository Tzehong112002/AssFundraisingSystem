using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


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
                string str = "SELECT * FROM Account";
                SqlCommand cmd = new SqlCommand(str);
                SqlDataAdapter sda = new SqlDataAdapter(cmd.CommandText, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                RowCount = dt.Rows.Count;
                for (int i = 0; i < RowCount; i++)
                {
                    string UsernameDBA = dt.Rows[i]["Username"].ToString();
                    string PasswordDBA = dt.Rows[i]["Password"].ToString();

                    if (UsernameDBA == username && PasswordDBA == password)
                    {
                        con.Close();
                        Session["Username"] = username;
                        Response.Redirect("program.aspx");
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