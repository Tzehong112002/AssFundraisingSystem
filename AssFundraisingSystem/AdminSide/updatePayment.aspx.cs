using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AssFundraisingSystem.AdminSide
{
    public partial class updatePayment : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["MYConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {//                                       if
                string id = Request.QueryString["id"] ?? "";
                bool found = false;

                //
                string sql = "SELECT * FROM Payment WHERE PaymentID = @Id";

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
                    paymentStatus.Text = (string)dr["paymentStatus"];
                }
                //
                dr.Close();
                con.Close();

                if (!found)
                {
                    Response.Redirect("paymentHistory.aspx");
                }

            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Server.Transfer("paymentHistory.aspx");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //retrive id from url
            string id = Request.QueryString["id"];
            //
            string sql = "UPDATE Payment SET paymentStatus = @status WHERE PaymentID = @Id";

            SqlConnection con = new SqlConnection(cs);

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@status", paymentStatus.Text);

            con.Open();

            cmd.ExecuteNonQuery();

            con.Close();
            Response.Write("<script>alert('Successful')</script>");

            Response.Redirect("paymentHistory.aspx");
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