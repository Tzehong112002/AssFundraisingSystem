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
    public partial class Edit : System.Web.UI.Page
    {
        string conStr = ConfigurationManager.ConnectionStrings["MYConnectionString"].ConnectionString;

        public int cateId = 9;


        public string cateImg = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    cateId = Convert.ToInt32(Request.QueryString["ID"]);
                }
                catch (FormatException) // Invalid id being passed
                {
                    Session["FormatException"] = true;
                    Response.Redirect("Artwork.aspx?id=1");
                    return;
                }

                GetDataFromDB();
            }
        }

        private void GetDataFromDB()
        {
            bool doesExist = false;

            string sql = @"SELECT * FROM Categories WHERE ID = @Id";

            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Id", cateId);

            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cid.Text = Convert.ToString(cateId);
                cTitle.Text = (string)dr["CategoryTitle"];




                cateDescription.Text = (string)dr["Description"];
                cateImg = (string)dr["Image"];
                doesExist = true;
            }

            imageCon.InnerHtml = "<img src='../Images/" + cateImg + "' alt='' class='img-thumbnail' id='image_preview'>";

            if (!doesExist)
            {
                Response.Redirect("Categories.aspx");
                return;
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {

                string title = cTitle.Text;
                string description = cateDescription.Text.Trim();
                string coid = cid.Text;
                string[] validFile = { ".jpg", ".png", ".jpeg" };
                string savePath = Server.MapPath("~/Images");

                string fileName = imageP.FileName;
                //    string extension = Path.GetExtension(imageP.PostedFile.FileName);
                //  string newFileName = fileName.Trim() + extension;

                SqlConnection con = new SqlConnection(conStr);

                string sql = "UPDATE Categories SET CategoryTitle=@title,Description=@cateDescription,Image=@image WHERE ID=@Id";
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@cateDescription", description);
                cmd.Parameters.AddWithValue("@image", fileName);
                cmd.Parameters.AddWithValue("@Id", coid);
                con.Open();


                cmd.ExecuteNonQuery();
                Response.Write(cmd.ExecuteNonQuery().ToString());
                Response.Redirect("Categories.aspx");

                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");

            }
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