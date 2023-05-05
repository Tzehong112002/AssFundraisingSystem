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
        int eventId;
        string  imagePath = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Retrieve the EventID from the query string parameter
                if (!int.TryParse(Request.QueryString["EventID"], out eventId))
                {
                    Response.Redirect("ProgramList.aspx");
                }

                // Retrieve the categories for the dropdownlist from the categories table
                using (SqlConnection con = new SqlConnection(cs))
                {
                    string query = "SELECT ID, CategoryTitle FROM Categories";
                    SqlCommand cmd = new SqlCommand(query, con);

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ListItem category = new ListItem();
                        category.Value = reader["ID"].ToString();
                        category.Text = reader["CategoryTitle"].ToString();
                        ddlCategories.Items.Add(category);
                    }

                    reader.Close();
                }

                // Retrieve the event details from the database
                using (SqlConnection con = new SqlConnection(cs))
                {
                    string query = "SELECT e.*, c.CategoryTitle FROM Event e JOIN Categories c ON e.CategoryID = c.ID WHERE e.EventID=@EventID";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@EventID", eventId);

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        txtEventName.Text = reader["EventName"].ToString();

                        // Set the dropdownlist's default title based on the category ID retrieved from the event
                        string categoryID = reader["CategoryID"].ToString();
                        ddlCategories.ClearSelection();
                        ListItem selectedCategory = ddlCategories.Items.FindByValue(categoryID);
                        if (selectedCategory != null)
                        {
                            selectedCategory.Selected = true;
                        }

                        cStartDate.SelectedDate = (DateTime)reader["EventStartDate"];
                        cEndDate.SelectedDate = (DateTime)reader["EventEndDate"];
                        txtTarget.Text = reader["EventTarget"].ToString();
                        txtDesc.Text = reader["EventDesc"].ToString();

                        // Retrieve the image path from the database
                        imagePath = reader["EventImg"].ToString();
                    }
                    else
                    {
                        Response.Redirect("ProgramList.aspx");
                    }

                    reader.Close();
                }
            }
        }





        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string Name = txtEventName.Text;
                string Categories = ddlCategories.SelectedItem.Value; // corrected to use ddlCategories control
                string StartDate = cStartDate.SelectedDate.ToString();
                string EndDate = cEndDate.SelectedDate.ToString();
                string Target = txtTarget.Text;
                string Description = txtDesc.Text;

                string fileName = "EventImg";
                string fileextension = "jpg";

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
                    fileextension = Path.GetExtension(ImgUpload.FileName);
                    ImgUpload.PostedFile.SaveAs(Server.MapPath("../AdminSide/Img/" + fileName + "/" + Name + fileextension));
                    imagePath = "../AdminSide/Img/" + fileName + "/" + Name + fileextension;
                }


                if (string.IsNullOrEmpty(txtEventName.Text) || ddlCategories.SelectedValue == "0" || cStartDate.SelectedDate == DateTime.MinValue || cEndDate.SelectedDate == DateTime.MinValue || string.IsNullOrEmpty(txtTarget.Text) || string.IsNullOrEmpty(txtDesc.Text) || ImgUpload.PostedFile == null || string.IsNullOrEmpty(ImgUpload.PostedFile.FileName))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('Please fill out all fields.');", true);
                }
                else
                {
                    int eventid = int.Parse(Request.QueryString["EventID"]);
                    string sql = "Update Event SET  CategoryID=@CategoryID, EventName=@EventName, EventTarget=@EventTarget, EventDesc=@EventDesc, EventStartDate=@EventStartDate, EventEndDate=@EventEndDate";
                    if (!string.IsNullOrEmpty(imagePath))
                    {
                        sql += ", EventImg=@EventImg";
                    }
                    sql += " WHERE EventID=@eventid ";
                    SqlConnection con = new SqlConnection(cs);
                    SqlCommand cmd = new SqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("@eventid", eventid);
                    cmd.Parameters.AddWithValue("@CategoryID", Categories);
                    cmd.Parameters.AddWithValue("@EventName", Name);
                    cmd.Parameters.AddWithValue("@EventTarget", Target);
                    cmd.Parameters.AddWithValue("@EventDesc", Description);
                    cmd.Parameters.AddWithValue("@EventStartDate", DateTime.Parse(StartDate));
                    cmd.Parameters.AddWithValue("@EventEndDate", DateTime.Parse(EndDate));
                    if (!string.IsNullOrEmpty(imagePath))
                    {
                        cmd.Parameters.AddWithValue("@EventImg", imagePath);
                    }

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Program Edit Successfully!')</script>");

                    Response.Redirect("ProgramList.aspx");
                }

                
            }
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

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProgramList.aspx");
        }
    }
}