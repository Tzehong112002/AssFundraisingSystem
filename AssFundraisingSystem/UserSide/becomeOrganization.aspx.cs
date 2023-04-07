using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AssFundraisingSystem.UserSide
{
    public partial class becomeOrganization : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["MYConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null){
                Response.Redirect("../UserSide/Login.aspx");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid) {
                String companyName = txtCompanyName.Text;
                String UserID = Session["UserID"].ToString().Trim();

                String Status = "Pending";
                string pathImgFront = "unknown";
                string pathImgBack = "unknown";
                string fileNameFront = "IC_Front";
                string fileNameBack = "IC_Back";
                string fileextension = "jpg";

                if (UploadFrontIC.HasFile)
                {
                    String pictureName = UploadFrontIC.FileName;
                    fileextension = Path.GetExtension(UploadFrontIC.FileName);
                    UploadFrontIC.PostedFile.SaveAs(Server.MapPath("../AdminSide/Img/" + fileNameFront + "/" + UserID + fileextension));
                    pathImgFront = "../AdminSide/Img/" + fileNameFront + "/" + UserID + fileextension;


                }
                if (UploadBackIC.HasFile)
                {
                    String pictureName = UploadBackIC.FileName;
                    fileextension = Path.GetExtension(UploadBackIC.FileName);
                    UploadBackIC.PostedFile.SaveAs(Server.MapPath("../AdminSide/Img/" + fileNameBack + "/" + UserID + fileextension));
                    pathImgBack = "../AdminSide/Img/" + fileNameBack + "/" + UserID + fileextension;

                }

                string sql = "UPDATE Account SET submitCompanyName = @companyName, StatusBecomeOrganization = @Status, submitICFront = @pathImgFront,submitICBack = @pathImgBack WHERE UserID = @UserID";

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@companyName", companyName);
                cmd.Parameters.AddWithValue("@Status", Status);
                cmd.Parameters.AddWithValue("@pathImgFront", pathImgFront);
                cmd.Parameters.AddWithValue("@pathImgBack", pathImgBack);
                cmd.Parameters.AddWithValue("@UserID", UserID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Program Submit Successfully!')</script>");


            }
        }
    }
}