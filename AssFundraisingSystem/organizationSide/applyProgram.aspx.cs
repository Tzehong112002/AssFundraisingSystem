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

                String StartDate = cStartDate.SelectedDate.ToString();
                String EndDate = cEndDate.SelectedDate.ToString();
                DateTime startDateTime;
                DateTime endDateTime;

                if (!DateTime.TryParse(StartDate, out startDateTime))
                {
                    ErrorMessage("Invalid start date format. Please select a valid date.");
                    return;
                }

                if (!DateTime.TryParse(EndDate, out endDateTime))
                {
                    ErrorMessage("Invalid end date format. Please select a valid date.");
                    return;
                }

                if (cStartDate.SelectedDate < DateTime.Today || cEndDate.SelectedDate < DateTime.Today)
                {
                    ErrorMessage("Start and end dates must be on or after the current date.");
                    return;
                }
                if (cEndDate.SelectedDate <= cStartDate.SelectedDate)
                {
                    ErrorMessage("End date must be after start date.");
                    return;
                }

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

        protected void cStartDate_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.Date < DateTime.Today)
            {
                e.Day.IsSelectable = false;
                e.Cell.ForeColor = System.Drawing.Color.Gray;
            }
        }

        protected void cEndDate_DayRender(object sender, DayRenderEventArgs e)
        {

            if (cStartDate.SelectedDate != null && e.Day.Date < cStartDate.SelectedDate)
            {
                e.Day.IsSelectable = false;
                e.Cell.ForeColor = System.Drawing.Color.Gray;
            }

        }

        protected void ErrorMessage(string msg)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ErrorMessage", "alert('" + msg + "');", true);
        }
    }
}
