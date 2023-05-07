using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Security;
using System.Configuration;
using System.IO;

namespace AssFundraisingSystem.AdminSide
{
    public partial class Create : System.Web.UI.Page
    {
        string conStr = ConfigurationManager.ConnectionStrings["CategoriesEntities1"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string title = cateTitle.Text.Trim();

            string cateDescription = cateDesc.Text.Trim();

            string[] validFile = { ".jpg", ".png", ".jpeg" };
            string savePath = Server.MapPath("~/Images");

            string fileName = cateImg.FileName;
            string extension = Path.GetExtension(cateImg.PostedFile.FileName);
            string newFileName = title.Trim() + extension;
            //new Changes Below
            int titleExists = checkTitle(title);

            if (titleExists > 0)
            {
                Literal1.Text = "<p class='alert alert-danger'>Title already exists. Please try another.</p>";
            }
            else
            {
                SqlConnection con = new SqlConnection(conStr);

                string sql = "Insert into Categories(CategoryTitle,Description, Status, Image) VALUES (@title,@cateDescription,@status, @img)";
                SqlCommand cmd = new SqlCommand(sql, con);


                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@cateDescription", cateDescription);
                cmd.Parameters.AddWithValue("@status", "True");
                cmd.Parameters.AddWithValue("@img", newFileName);

                con.Open();

                int insert = cmd.ExecuteNonQuery();
                if (insert > 0)
                {
                    cateImg.SaveAs(savePath + "\\" + newFileName);
                    Response.Redirect("Categories.aspx");
                }
                con.Close();
            }
        }

        private int checkTitle(String title)
        {
            SqlConnection con = new SqlConnection(conStr);
            string query = "SELECT COUNT(*) FROM Categories WHERE CategoryTitle= '" + title + "' ";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int count = (int)cmd.ExecuteScalar();
            con.Close();
            return count;
        }
        // until here 

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