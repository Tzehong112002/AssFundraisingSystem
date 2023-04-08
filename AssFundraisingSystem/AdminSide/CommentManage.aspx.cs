using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace AssFundraisingSystem.AdminSide
{
    public partial class CommentManage : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["MYConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindRepeaterComment();
            }
        }

        private void BindRepeaterComment()
        {
            int id = Convert.ToInt32(Session["EventID"] ?? Request.QueryString["EventID"]);

            using (SqlConnection con = new SqlConnection(cs))
            {
                using (SqlCommand cmd = new SqlCommand("Select * from Comment WHERE EventID=@EventID ORDER BY DateCommented DESC", con))
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



        protected void btnDelComment_Click(object sender, EventArgs e)
        {
            Button btnDelComment = (Button)sender;
            string commentID = btnDelComment.CommandArgument;



            using (SqlConnection con = new SqlConnection(cs))
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Comment WHERE CommentID = @CommentID", con))
                {
                    cmd.Parameters.AddWithValue("@CommentID", commentID);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            this.BindRepeaterComment();
        }

    }
}