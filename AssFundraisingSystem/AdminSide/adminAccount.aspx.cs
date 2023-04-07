using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace AssFundraisingSystem.AdminSide
{
    public partial class adminAccount : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["MYConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindRepeater();
            }
        }

        private void BindRepeater()
        {

            using (SqlConnection con = new SqlConnection(cs))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Account WHERE Roles = 'Admin'", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            RepeaterAdmin.DataSource = dt;
                            RepeaterAdmin.DataBind();
                        }
                    }
                }
            }
        }

        protected void DeleteUser(object sender, EventArgs e)
        {

            LinkButton btnDecline = (LinkButton)sender;
            string UserID = btnDecline.CommandArgument;



            using (SqlConnection con = new SqlConnection(cs))
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Account WHERE UserID = @UserID", con))
                {
                    cmd.Parameters.AddWithValue("@UserID", UserID);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            this.BindRepeater();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddAdmin.aspx");
        }
    }
}