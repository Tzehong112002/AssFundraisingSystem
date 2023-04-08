﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Runtime.Remoting.Messaging;

namespace AssFundraisingSystem.UserSide
{
    public partial class EventPage : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["MYConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                int id = Convert.ToInt32(Session["EventID"] ?? Request.QueryString["EventID"]);

                SqlConnection con = new SqlConnection(cs);

                SqlCommand cmd = new SqlCommand("SELECT * FROM Event WHERE EventID=@EventID", con);
                cmd.Parameters.AddWithValue("@EventID", id);

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    EventImage.ImageUrl = reader["EventIMG"].ToString();

                    object donatedObj = reader["DonatedAmount"];
                    decimal donated;
                    if (donatedObj != DBNull.Value && donatedObj != null)
                    {
                        donated = (decimal)donatedObj;
                    }
                    else
                    {
                        donated = 0;
                    }

                    string formattedDonated = "RM" + donated.ToString("N2");
                    lblDonated.Text = formattedDonated;

                    decimal target = (decimal)reader["EventTarget"];
                    string formattedTarget = "RM" + target.ToString("N2");
                    lblTarget.Text = formattedTarget;

                    
                    int progress = Convert.ToInt32((donated / target) * 100);

                    if(progress > 100)
                    {
                        progress = 100;
                    }

                    string progressPercent = progress.ToString();



                    progressBar.Attributes.Add("style", "width: " + progressPercent + "%");
                    progressBar.Attributes.Add("aria-valuenow", progressPercent);
                    lblPercentage.InnerText = progressPercent;

                    lblEventTitle.Text = reader["EventName"].ToString();
                    lblEventDetail.Text = reader["EventDesc"].ToString();


                    
                }
                con.Close();

                this.BindRepeaterParticipant();

                this.BindRepeaterComment();

            }
        }

        private void BindRepeaterParticipant()
        {
            int EventID = Convert.ToInt32(Request.QueryString["EventID"] ?? Session["EventID"]);

            using (SqlConnection con = new SqlConnection(cs))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT a.ProfilePic, a.Username, a.Name, 'Donated RM ' + CONVERT(varchar(10), p.Amount) AS Amount FROM Account a INNER JOIN Payment p ON a.UserID = p.UserID WHERE p.EventID = @EventID", con))
                {
                    cmd.Parameters.AddWithValue("@EventID", EventID);
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            parRepeater.DataSource = dt;
                            parRepeater.DataBind();
                        }
                    }
                }
            }
        }

        private void BindRepeaterComment()
        {
            int id = Convert.ToInt32(Session["EventID"] ?? Request.QueryString["EventID"]);

            using (SqlConnection con = new SqlConnection(cs))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT c.*, a.ProfilePic, a.Username FROM Comment c JOIN Account a ON c.UserID = a.UserID WHERE c.EventID=@EventID ORDER BY c.DateCommented DESC", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            cmd.Parameters.AddWithValue("@EventID", id);
                            sda.Fill(dt);
                            commentRepeater.DataSource = dt;
                            commentRepeater.DataBind();

                        }
                    }
                }
            }
        }

        protected void donatebtn_Click(object sender, EventArgs e)
        {
            int Eventid = Convert.ToInt32(Session["EventID"] ?? Request.QueryString["EventID"]);
            Response.Redirect("Payment.aspx?EventID=" + Eventid);
        }

        protected void commentRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }
    }
}