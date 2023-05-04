using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;
using System.Data.SqlClient;

namespace AssFundraisingSystem.AdminSide
{
    public partial class dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int totalVisitor;
            if (!IsPostBack)
            {
                // Retrieve total number of events with "Approved" status
                string cs = ConfigurationManager.ConnectionStrings["MYConnectionString"].ConnectionString;
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Event WHERE EventStatus='Approved'", con))
                    {
                        int totalEvents = (int)cmd.ExecuteScalar();
                        totalEvent.Text = totalEvents.ToString();
                    }
                }

                // Retrieve total number of users with "User" role
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Account WHERE Roles='User' OR Roles='Organization'", con))
                    {
                        int totalUsers = (int)cmd.ExecuteScalar();
                        totalUser.Text = totalUsers.ToString();
                    }
                }


                // Retrieve total amount of donations
                decimal totalDonation = 0;
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT SUM(CONVERT(decimal(10,2), Amount)) FROM Payment", con))
                    {
                        var result = cmd.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            totalDonation = Convert.ToDecimal(result);
                        }
                    }
                }
                totalDonationLabel.Text = totalDonation.ToString("C");


                totalVisitor = Convert.ToInt32(Application["TotalVisitors"]);
                ttlVisitor.Text = totalVisitor.ToString();

            }
        }
    }
}
