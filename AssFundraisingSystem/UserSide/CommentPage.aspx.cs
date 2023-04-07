using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AssFundraisingSystem.UserSide
{
    public partial class CommentPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            string query = "INSERT INTO Comment (CommentContent, DateCommented) VALUES (@CommentText, @DateCommented)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CommentText", txtComment.Text);
                    command.Parameters.AddWithValue("@DateCommented", DateTime.Now);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            txtComment.Text = "";
        }
    }
}