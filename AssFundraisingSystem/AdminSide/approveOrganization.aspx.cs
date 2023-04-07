using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AssFundraisingSystem.AdminSide
{
    public partial class approveOrganization : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["MYConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindRepeater();
            }


        }

        private void BindRepeater()
        {

            using (SqlConnection con = new SqlConnection(cs))
            {
                String status = "Pending";
                String Roles = "User";

                /*retrieve only show the event that select by one user*/
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Account WHERE Roles = @Roles AND StatusBecomeOrganization = @status", con))
                {

                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@Roles", Roles);

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            RepeaterProgramApply.DataSource = dt;
                            RepeaterProgramApply.DataBind();
                        }
                    }
                }
            }
        }

        protected void UpdateRequest(object sender, EventArgs e)
        {

            LinkButton btnApprove = (LinkButton)sender;
            string UserID = btnApprove.CommandArgument;



            using (SqlConnection con = new SqlConnection(cs))
            {
                String NewStatusBecomeOrganization = "";
                String NewsubmitICFront = "";
                String NewsubmitICBack = "";
                String NewsubmitCompanyName = "";
                String newRoles = "Organization";
                

                using (SqlCommand cmd = new SqlCommand("UPDATE Account SET submitICFront = @icFront, submitICBack = @icBack, submitCompanyName = @companyName, Roles = @Roles, StatusBecomeOrganization = @status WHERE UserID = @userId", con))
                {
                    cmd.Parameters.AddWithValue("@icFront", NewsubmitICFront);
                    cmd.Parameters.AddWithValue("@icBack", NewsubmitICBack);
                    cmd.Parameters.AddWithValue("@companyName", NewsubmitCompanyName);
                    cmd.Parameters.AddWithValue("@Roles", newRoles);
                    cmd.Parameters.AddWithValue("@status", NewStatusBecomeOrganization);
                    cmd.Parameters.AddWithValue("@userId", UserID);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            this.BindRepeater();
        }

        protected void DeleleRequest(object sender, EventArgs e)
        {

            LinkButton btnDecline = (LinkButton)sender;
            string UserID = btnDecline.CommandArgument;



            using (SqlConnection con = new SqlConnection(cs))
            {
                String NewStatusBecomeOrganization = "";
                String NewsubmitICFront = "";
                String NewsubmitICBack = "";
                String NewsubmitCompanyName = "";



                using (SqlCommand cmd = new SqlCommand("UPDATE Account SET submitICFront = @icFront, submitICBack = @icBack, submitCompanyName = @companyName, StatusBecomeOrganization = @status WHERE UserID = @userId", con))
                {
                    cmd.Parameters.AddWithValue("@icFront", NewsubmitICFront);
                    cmd.Parameters.AddWithValue("@icBack", NewsubmitICBack);
                    cmd.Parameters.AddWithValue("@companyName", NewsubmitCompanyName);;
                    cmd.Parameters.AddWithValue("@status", NewStatusBecomeOrganization);
                    cmd.Parameters.AddWithValue("@userId", UserID);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            this.BindRepeater();
        }
    }
}