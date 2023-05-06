﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace AssFundraisingSystem.AdminSide
{
    public partial class CommentEdit : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["MYConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            string commentid = Request.QueryString["CommentID"];
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("SELECT * FROM Comment WHERE EventID = '" + commentid + "'", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();


            if (dr.Read())
            {

                txtComment.Text = dr["CommentContent"].ToString();
            }




            dr.Close();
            con.Close();
            

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {
                String CommentContent = txtComment.Text;
                DateTime DateCommented = Calendar1.SelectedDate;

                int eventid = Int32.Parse(Request.QueryString["EventID"]);
                int commentid = Int32.Parse(Request.QueryString["CommentID"]);
                string sql = "Update Comment SET DateCommented=@DateCommented, CommentContent=@CommentContent WHERE CommentID=@commentid ";

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@CommentID", commentid);
                cmd.Parameters.AddWithValue("@CommentContent", CommentContent);
                cmd.Parameters.AddWithValue("@DateCommented", DateCommented);



                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Comment Edited Successfully!')</script>");

                Response.Redirect("CommentManage.aspx?EventId=" + eventid);

            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            int eventid = Int32.Parse(Request.QueryString["EventID"]);
            Response.Redirect("CommentManage.aspx?EventId=" + eventid);
        }

        void Page_Error()
        {
            // Get the exception object
            Exception ex = Server.GetLastError();

            // Clear the error so it doesn't propagate further
            Server.ClearError();

            // Display a message indicating that there might be an error
            Response.Write("<h1>Sorry, an error occurred while processing your request.</h1>");

            // Display a hyperlink that allows the user to go back
            Response.Write("<p><a href='javascript:history.back()' style='color:red; text-decoration:none;'>Go back</a></p>");
        }

    }
}