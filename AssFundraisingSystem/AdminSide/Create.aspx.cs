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
        string conStr = ConfigurationManager.ConnectionStrings["MYConnectionString"].ConnectionString;
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
}