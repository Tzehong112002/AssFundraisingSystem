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
    public partial class program : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["MYConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {

                // Increment TotalVisitors count
                Application.Lock();
                Application["TotalVisitors"] = (int)Application["TotalVisitors"] + 1;
                Application.UnLock();


                this.BindRepeater();
            }
        }

        private void BindRepeater()
        {

            using (SqlConnection con = new SqlConnection(cs))
            {
                using (SqlCommand cmd = new SqlCommand("Select * from Event WHERE EventStatus='Approved' AND EventEndDate >= CURRENT_TIMESTAMP", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            RepeaterEventList.DataSource = dt;
                            RepeaterEventList.DataBind();
                        }
                    }
                }
            }
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            Response.Redirect("EventPage.aspx");
        }
    }
}