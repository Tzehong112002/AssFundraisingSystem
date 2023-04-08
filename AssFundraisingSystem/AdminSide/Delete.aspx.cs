using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

namespace AssFundraisingSystem
{
    public partial class Delete : System.Web.UI.Page
    {
        string conStr = ConfigurationManager.ConnectionStrings["MYConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            string delid = Request.QueryString["id"] ?? "";

            string delsql = "DELETE FROM Categories WHERE ID = @Id";

            SqlConnection conn = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand(delsql, conn);
            cmd.Parameters.AddWithValue("@Id", delid);

            conn.Open();

            cmd.ExecuteNonQuery();

            conn.Close();

            Response.Redirect("Categories.aspx");
            
        }
    }
}