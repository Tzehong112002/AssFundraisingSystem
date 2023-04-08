using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;


namespace AssFundraisingSystem.AdminSide
{
    public partial class editProgram : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["MYConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            string eventid = Request.QueryString["EventID"];
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("SELECT * FROM Event WHERE EventID = '" + eventid + "'", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();


            if (dr.Read()) {
                txtName.Text = dr["EventName"].ToString();

                txtTarget.Text = dr["EventTarget"].ToString();
                txtDesc.Text = dr["EventDesc"].ToString();
                txtCategories.Text = (dr["Categories"] != null) ? (string)dr["Categories"] : " ";
            }

            


            dr.Close();
            con.Close();

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {
                String Name = txtName.Text;
                String Categories = txtCategories.SelectedItem.Value;
                String StartDate = cStartDate.SelectedDate.ToString();
                String EndDate = cEndDate.SelectedDate.ToString();
                String Target = txtTarget.Text;
                String Description = txtDesc.Text;

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

                int eventid = Int32.Parse(Request.QueryString["EventID"]);
                string sql = "Update Event SET  Categories=@Categories, EventImg=@EventImg, EventName=@EventName, EventTarget=@EventTarget, EventDesc= @EventDesc, EventStartDate=@EventStartDate, EventEndDate=@EventEndDate WHERE EventID=@eventid ";
                
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@eventid", eventid);
                cmd.Parameters.AddWithValue("@Categories", Categories);
                cmd.Parameters.AddWithValue("@EventImg", pathImg);
                cmd.Parameters.AddWithValue("@EventName", Name);
                cmd.Parameters.AddWithValue("@EventTarget", Target);
                cmd.Parameters.AddWithValue("@EventDesc", Description);
                cmd.Parameters.AddWithValue("@EventStartDate", DateTime.Parse(StartDate));
                cmd.Parameters.AddWithValue("@EventEndDate", DateTime.Parse(EndDate));


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Program Edit Successfully!')</script>");

                Response.Redirect("ProgramList.aspx");

            }

            
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProgramList.aspx");
        }
    }
}