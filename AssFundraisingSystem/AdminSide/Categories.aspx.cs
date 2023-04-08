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
    public partial class Categories : Page
    {
        private readonly string conStr = ConfigurationManager.ConnectionStrings["MYConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection con = new SqlConnection(conStr);
                SqlCommand cmd;
                SqlDataAdapter dta;

                string sql = "SELECT * FROM Categories";
                cmd = new SqlCommand(sql, con);
                con.Open();
                dta = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                dta.Fill(table);
                cateRepeater.DataSource = table;
                cateRepeater.DataBind();
            }

            

        }

      
    }

}