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
    public partial class EventFilter : System.Web.UI.Page
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
            string category = Request.QueryString["CategoryTitle"];
            using (SqlConnection con = new SqlConnection(cs))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Event WHERE Categories = @category AND EventEndDate >= CURRENT_TIMESTAMP AND EventStatus='Approved'", con))
                {
                    cmd.Parameters.AddWithValue("@category", category);
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
    }
}