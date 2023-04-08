﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AssFundraisingSystem.AdminSide
{
    public partial class Ban : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["MYConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {//                                       if
                string id = Request.QueryString["id"] ?? "";
                bool found = false;

                //
                string sql = "SELECT * FROM Account WHERE UserID = @Id";

                //
                SqlConnection con = new SqlConnection(cs);

                //
                SqlCommand cmd = new SqlCommand(sql, con);
                //
                cmd.Parameters.AddWithValue("@Id", id);
                //
                con.Open();
                //
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    //record found
                    found = true;
                    lblId.Text = dr[0].ToString();
                    lblName.Text = (string)dr["Name"];
                    banStatus.Text = (string)dr["BanStatus"];
                }
                //
                dr.Close();
                con.Close();

                if (!found)
                {
                    Response.Redirect("ParticipantsRecord.aspx");
                }

            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Server.Transfer("ParticipantsRecord.aspx");
        }

        protected void btnBan_Click(object sender, EventArgs e)
        {
            //retrive id from url
            string id = Request.QueryString["id"];
            //
            string sql = "UPDATE Account SET BanStatus = @status WHERE UserID = @Id";

            SqlConnection con = new SqlConnection(cs);

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@status", banStatus.Text);

            con.Open();

            cmd.ExecuteNonQuery();

            con.Close();

            Response.Redirect("ParticipantsRecord.aspx");
        }
    }
}