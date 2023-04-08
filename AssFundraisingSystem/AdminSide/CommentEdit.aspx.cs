using System;
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
            
            string eventid = Request.QueryString["EventID"];
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("SELECT * FROM Comment WHERE EventID = '" + eventid + "'", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();


            if (dr.Read())
            {
                txtName.Text = dr["Username"].ToString();

                txtComment.Text = dr["CommentContent"].ToString();
            }




            dr.Close();
            con.Close();
            

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {
                String Username = txtName.Text;
                String CommentContent = txtComment.Text;

                int eventid = Int32.Parse(Request.QueryString["EventID"]);
                int commentid = Int32.Parse(Request.QueryString["CommentID"]);
                string sql = "Update Comment SET Username=@Username, CommentContent=@CommentContent WHERE CommentID=@commentid ";

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@CommentID", commentid);
                cmd.Parameters.AddWithValue("@Username", Username);
                cmd.Parameters.AddWithValue("@CommentContent", CommentContent);
                


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
    }
}