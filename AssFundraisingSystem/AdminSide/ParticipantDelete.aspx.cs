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
    public partial class ParticipantDelete : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["MYConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {//                                       
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

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            //retrive id from url
            string id = Request.QueryString["id"];
            //
            string sql = "DELETE FROM Account WHERE UserID = @Id";

            SqlConnection con = new SqlConnection(cs);

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@Id", id);

            con.Open();

            cmd.ExecuteNonQuery();

            con.Close();

            Response.Write("<script>alert('Successful')</script>");
            Response.Redirect("ParticipantsRecord.aspx");
        }
    }
}