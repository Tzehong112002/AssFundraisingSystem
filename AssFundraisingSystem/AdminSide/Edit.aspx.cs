using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

namespace AssFundraisingSystem.AdminSide
{
    public partial class Edit : Page
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["MYConnectionString"].ConnectionString;

        private int categoryId;
        private string categoryImage;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((!this.IsPostBack))
            {
                if (!int.TryParse(Request.QueryString["ID"], out categoryId))
                {
                    Session["FormatException"] = true;
                    Response.Redirect("Artwork.aspx?id=1");
                    return;
                }

                if (!GetDataFromDB())
                {
                    Response.Redirect("Categories.aspx");
                    return;
                }

                imageCon.InnerHtml = $"<img src='../Images/{categoryImage}' alt='' class='img-thumbnail' id='image_preview'>";
            }
        }

        private bool GetDataFromDB()
        {
            string sql = "SELECT CategoryTitle, Description, Image FROM Categories WHERE ID = @CategoryId";

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@CategoryId", categoryId);

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            cTitle.Text = reader.GetString(reader.GetOrdinal("CategoryTitle"));
                            cateDescription.Text = reader.GetString(reader.GetOrdinal("Description"));
                            categoryImage = reader.GetString(reader.GetOrdinal("Image"));
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string title = cTitle.Text;
                string description = cateDescription.Text.Trim();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string sql = "UPDATE Categories SET CategoryTitle=@title,Description=@cateDescription WHERE ID=@Id";
                    SqlCommand cmd = new SqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@cateDescription", description);
                    cmd.Parameters.AddWithValue("@Id", categoryId);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                Response.Redirect("Categories.aspx");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }



        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Categories.aspx");
        }
    }
}
