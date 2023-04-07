using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace AssFundraisingSystem.organizationSide
{
    public partial class applyProgram : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["MYConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("../UserSide/OrganizationLogin.aspx");

            }
            

        }

        protected void btnApply_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                String Userid = Session["UserID"].ToString();
                String Name = txtEventName.Text;
                String Categories = ddlCategories.SelectedItem.Value;
                String StartDate = cStartDate.SelectedDate.ToString();
                String EndDate = cEndDate.SelectedDate.ToString();
                String Target = txtTarget.Text;
                String Description = txtTarget.Text;
                String Status = "NTAproved";
                string pathImg = "unknown";
                string fileName = "EventImg";
                string fileextension = "jpg";

                if (ImgUpload.HasFile)
                {
                    String pictureName = ImgUpload.FileName;
                    fileextension = Path.GetExtension(ImgUpload.FileName);
                    ImgUpload.PostedFile.SaveAs(Server.MapPath("../AdminSide/Img/" + fileName + "/" + Name + fileextension));
                    pathImg = "../AdminSide/Img/" + fileName + "/" + Name + fileextension;


                }

                string sql = "INSERT INTO Event (Categories, EventImg, EventName, EventTarget, EventDesc, EventStartDate, EventEndDate,EventStatus,UserID) VALUES (@Categories, @EventImg, @EventName, @EventTarget, @EventDesc, @EventStartDate, @EventEndDate,@EventStatus,@UserID) ";

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@Categories", Categories);
                cmd.Parameters.AddWithValue("@EventImg", pathImg);
                cmd.Parameters.AddWithValue("@EventName", Name);
                cmd.Parameters.AddWithValue("@EventTarget", Target);
                cmd.Parameters.AddWithValue("@EventDesc", Description);
                cmd.Parameters.AddWithValue("@EventStartDate", DateTime.Parse(StartDate));
                cmd.Parameters.AddWithValue("@EventEndDate", DateTime.Parse(EndDate));
                cmd.Parameters.AddWithValue("@EventStatus", Status);
                cmd.Parameters.AddWithValue("@UserID", Userid);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Program Submit Successfully!')</script>");

                Response.Redirect("applyProgram.aspx");

            }
        }
    }
}