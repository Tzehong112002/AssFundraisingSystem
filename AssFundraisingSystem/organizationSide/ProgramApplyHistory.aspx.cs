using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace AssFundraisingSystem.organizationSide
{
    public partial class ProgramApplyHistory : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["MYConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("../UserSide/OrganizationLogin.aspx");

            }
            else {
                if (!this.IsPostBack)
                {
                    this.BindRepeater();
                }
            }
            
        }

        private void BindRepeater()
        {
            String UserID = Session["UserID"].ToString().Trim();
            using (SqlConnection con = new SqlConnection(cs))
            {
                /*retrieve only show the event that select by one user*/
                using (SqlCommand cmd = new SqlCommand("SELECT Event.*, Account.Name FROM Event INNER JOIN Account ON Event.UserID = Account.UserID WHERE Event.UserID = @UserID;", con))
                {

                    cmd.Parameters.AddWithValue("@UserID", UserID);
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            RepeaterHistory.DataSource = dt;
                            RepeaterHistory.DataBind();
                        }
                    }
                }
            }
        }
    }
}