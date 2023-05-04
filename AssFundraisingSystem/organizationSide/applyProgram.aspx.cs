using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
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

            if (!IsPostBack)
            {
                PopulateCategoryDropDownList();
            }
        }

        protected void btnApply_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string userId = Session["UserID"].ToString();
                string name = txtEventName.Text;
                int categoryId = Convert.ToInt32(ddlCategories.SelectedValue);
                string startDate = cStartDate.SelectedDate.ToString();
                string endDate = cEndDate.SelectedDate.ToString();
                decimal target = Convert.ToDecimal(txtTarget.Text);
                string description = txtDesc.Text;
                string status = "Not Approved";
                string imgPath = "";
                string fileName = "EventImg";
                string fileExtension = "jpg";

                if (ImgUpload.HasFile)
                {
                    string pictureName = ImgUpload.FileName;
                    fileExtension = Path.GetExtension(pictureName);
                    imgPath = "../AdminSide/Img/" + fileName + "/" + name + fileExtension;
                    ImgUpload.SaveAs(Server.MapPath(imgPath));
                }

                string sql = "INSERT INTO Event (CategoryID, EventIMG, EventName, EventTarget, EventDesc, EventStartDate, EventEndDate, EventStatus, UserID) VALUES (@CategoryID, @EventIMG, @EventName, @EventTarget, @EventDesc, @EventStartDate, @EventEndDate, @EventStatus, @UserID)";

                using (SqlConnection con = new SqlConnection(cs))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@CategoryID", categoryId);
                        cmd.Parameters.AddWithValue("@EventIMG", imgPath);
                        cmd.Parameters.AddWithValue("@EventName", name);
                        cmd.Parameters.AddWithValue("@EventTarget", target);
                        cmd.Parameters.AddWithValue("@EventDesc", description);
                        cmd.Parameters.AddWithValue("@EventStartDate", DateTime.Parse(startDate));
                        cmd.Parameters.AddWithValue("@EventEndDate", DateTime.Parse(endDate));
                        cmd.Parameters.AddWithValue("@EventStatus", status);
                        cmd.Parameters.AddWithValue("@UserID", userId);

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "alert('Program submitted successfully!');", true);

                // Redirect to ProgramApplyHistory.aspx
                //Response.Redirect("ProgramApplyHistory.aspx");
            }
        }

        private void PopulateCategoryDropDownList()
        {
            string query = "SELECT ID, CategoryTitle FROM Categories";

            using (SqlConnection con = new SqlConnection(cs))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        ddlCategories.DataSource = reader;
                        ddlCategories.DataValueField = "ID";
                        ddlCategories.DataTextField = "CategoryTitle";
                        ddlCategories.DataBind();
                    }
                }
            }

            ddlCategories.Items.Insert(0, new ListItem("Select a category", ""));
        }
    }
}
