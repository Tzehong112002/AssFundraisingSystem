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
    public partial class historyPayment : System.Web.UI.Page
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
            String UserID = Session["UserID"].ToString().Trim();

            using (SqlConnection con = new SqlConnection(cs))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT p.*, a.Name AS AccountName, a.Email AS AccountEmail, e.EventName FROM Payment p INNER JOIN Account a ON p.UserID = a.UserID INNER JOIN Event e ON p.EventID = e.EventID", con))
                {
                    cmd.Parameters.AddWithValue("@UserID", UserID);
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            RepeaterEvent.DataSource = dt;
                            RepeaterEvent.DataBind();
                        }
                    }
                }
            }
        }
    }
}