using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;
using System.Data.SqlClient;
using System.Data;


namespace AssFundraisingSystem.AdminSide
{
    public partial class dashboard : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["MYConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            int totalVisitor;
            if (!IsPostBack)
            {
                this.BindRepeater();

                // Retrieve total number of events with "Approved" status

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

            this.BindRepeater2();
        }

        private void BindRepeater2()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Event WHERE EventStatus = 'Not Approved'", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            RepeaterDashboard2.DataSource = dt;
                            RepeaterDashboard2.DataBind();
                        }
                    }
                }
            }
        }


        private void BindRepeater()
        {


            using (SqlConnection con = new SqlConnection(cs))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT p.Amount, a.Name, e.EventName " +
                       "FROM Payment p " +
                       "INNER JOIN Account a ON p.UserID = a.UserID " +
                       "INNER JOIN Event e ON p.EventID = e.EventID", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            RepeaterDashboard.DataSource = dt;
                            RepeaterDashboard.DataBind();
                        }
                    }
                }
            }

        }



        void Page_Error()
        {
            // Get the exception object
            Exception ex = Server.GetLastError();

            // Clear the error so it doesn't propagate further
            Server.ClearError();

            // Display a message indicating that there might be an error
            Response.Write("<div style='text-align: center'><h1>Sorry, an error occurred while processing your request.</h1>");

            // Display a hyperlink that allows the user to go back
            Response.Write("<p><a href='javascript:history.back()' style='color:red; text-decoration:none;'>Go back</a></p></div>");
        }


    }
}
