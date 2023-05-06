using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AssFundraisingSystem.AdminSide
{
    public partial class paymentHistory : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["MYConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindGrid();
            }
        }

        private void BindGrid()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter("SELECT PaymentID, Name, Email, ContactNumber, PaymentStatus FROM Payment", con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        paymentListForm.DataSource = dt;
                        paymentListForm.DataBind();
                    }
                }
            }

            //Required for jQuery DataTables to work.
            paymentListForm.UseAccessibleHeader = true;
            paymentListForm.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
}