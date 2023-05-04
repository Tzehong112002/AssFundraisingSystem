using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace AssFundraisingSystem.AdminSide
{

    public partial class addProgram : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["MYConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Retrieve the categories from the database
                using (SqlConnection con = new SqlConnection(cs))
                {
                    string query = "SELECT ID, CategoryTitle FROM Categories";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    ddlCategories.DataSource = reader;
                    ddlCategories.DataTextField = "CategoryTitle";
                    ddlCategories.DataValueField = "ID";
                    ddlCategories.DataBind();
                }

                // Set the default text of the categories DropDownList control
                ddlCategories.Items.Insert(0, new ListItem("-- Select Category --", ""));
            }

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                String Name = txtEventName.Text;
                int CategoryID = Convert.ToInt32(ddlCategories.SelectedItem.Value);
                String StartDate = cStartDate.SelectedDate.ToString();
                String EndDate = cEndDate.SelectedDate.ToString();
                String Target = txtTarget.Text;
                String Description = txtDesc.Text;
                String Status = "Approved";
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

                string sql = "INSERT INTO Event (CategoryID, EventImg, EventName, EventTarget, EventDesc, EventStartDate, EventEndDate,EventStatus) VALUES (@CategoryID, @EventImg, @EventName, @EventTarget, @EventDesc, @EventStartDate, @EventEndDate,@EventStatus) ";

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@CategoryID", CategoryID);
                cmd.Parameters.AddWithValue("@EventImg", pathImg);
                cmd.Parameters.AddWithValue("@EventName", Name);
                cmd.Parameters.AddWithValue("@EventTarget", Target);
                cmd.Parameters.AddWithValue("@EventDesc", Description);
                cmd.Parameters.AddWithValue("@EventStartDate", DateTime.Parse(StartDate));
                cmd.Parameters.AddWithValue("@EventEndDate", DateTime.Parse(EndDate));
                cmd.Parameters.AddWithValue("@EventStatus", Status);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Program Added Successfully!')</script>");

                Response.Redirect("ProgramList.aspx");

            }

        }


        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProgramList.aspx");
        }
    }
}