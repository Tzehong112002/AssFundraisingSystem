using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            string delid = Request.QueryString["id"] ?? "";







            cmd.Parameters.AddWithValue("@Id", id);

            con.Open();

            cmd.ExecuteNonQuery();

            con.Close();

            Response.Redirect("ParticipantsRecord.aspx");
        }
    }
}