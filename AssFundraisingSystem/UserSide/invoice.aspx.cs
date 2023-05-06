using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;

namespace AssFundraisingSystem.UserSide
{
    public partial class invoice : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["MYConnectionString"].ConnectionString;

        string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm tt");

        [Obsolete]
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["DonateID"] != null)
            {
                if (!this.IsPostBack)
                {
                    if (Session["DonateID"] != null)
                    {
                        string donateID = Session["DonateID"].ToString();
                        //SQL Statement
                        string query = "SELECT * FROM Payment WHERE PaymentID = '" + donateID + "'";

                        SqlConnection con = new SqlConnection(cs);
                        con.Open();

                        //Sql Statement
                        SqlCommand cmd = new SqlCommand(query, con);

                        //Execute
                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.Read())
                        {
                            Label1.Text = dr["Name"].ToString();
                        }

                        //Close connection
                        dr.Close();
                        con.Close();
                    }

                    Label2.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    Label6.Text = DateTime.Now.ToString("HH:mm tt");
                    showgrid();
                    invoicePDF();
                    changePaymentStatus();
                }
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "alertMessage", "alert('You no has the permission to access!');window.location ='/UserSide/Login.aspx'", true);
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        private void showgrid()
        {

            SqlConnection con = new SqlConnection(cs);

            String myquery = "";
            string donateID = Session["DonateID"].ToString();

            myquery = "SELECT * FROM Payment WHERE PaymentID='" + donateID + "'";

            SqlCommand donationInfo_cmd = new SqlCommand(myquery, con);

            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = donationInfo_cmd;
            DataSet ds = new DataSet();
            sda.Fill(ds);

            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        int sum = 0;
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label x = (Label)e.Row.FindControl("lblamt");
                sum = sum + (int)double.Parse(x.Text);
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label x = (Label)e.Row.FindControl("lbltotal");
                x.Text = sum.ToString("0.00").Replace(",", ".");
            }
        }

        [Obsolete]
        protected void DownloadBtn_Click(object sender, EventArgs e)
        {
            string donationName = "";

            if (Session["DonateID"] != null)
            {
                string donateID = Session["DonateID"].ToString();

                //SQL Statement
                string query = "SELECT * FROM Payment WHERE PaymentID = '" + donateID + "'";

                SqlConnection con = new SqlConnection(cs);
                con.Open();

                //Sql Statement
                SqlCommand cmd = new SqlCommand(query, con);

                //Execute
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    donationName = dr["Name"].ToString();
                }

                //Close connection
                dr.Close();
                con.Close();
            }

            string logo = Server.MapPath("invoice.png");
            string footer = Server.MapPath("invoice-footer.png");
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    GridView1.RenderControl(hw);
                    string gridHTML = sw.ToString().Replace("\"", "'").Replace(System.Environment.NewLine, "");
                    StringBuilder sb = new StringBuilder();
                    sb.Append("<table width='100%' cellspacing='0' cellpadding='2'>");
                    sb.Append("<tr><td align='center' colspan='2'><img src='" + logo + "' width='300' height='100' /></td></tr>");
                    sb.Append("<tr><td align='center' style='background-color: #18B5F0; font-size: 20px' colspan = '2'><b>Invoice</b></td></tr>");
                    sb.Append("<tr><td colspan = '2'></td></tr>");
                    sb.Append("<tr><td><b>Name : </b>");
                    sb.Append(donationName);
                    sb.Append("</td><td align='right'><b>Order Date : </b>");
                    sb.Append(date);
                    sb.Append("</td></tr>");
                    sb.Append("</table>");
                    sb.Append("<br />");
                    sb.Append("<table>");
                    sb.Append("<tr>");
                    sb.Append("<td>");
                    sb.Append(gridHTML);
                    sb.Append("</td>");
                    sb.Append("</tr>");
                    sb.Append("</table>");
                    sb.Append("<footer>");
                    sb.Append("<br /><br /><br /><br />");
                    sb.Append("<img align='center' src='" + footer + "' width='350' height='70' />");
                    sb.Append("</footer>");

                    //Export HTML String as PDF.
                    StringReader sr = new StringReader(sb.ToString());
                    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename=Invoice (" + donationName + ").pdf");
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Write(pdfDoc);
                    Response.End();
                }
            }
        }

        protected void BackBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("/UserSide/EventPage.aspx");
        }

        [Obsolete]
        private void invoicePDF()
        {
            string donationName = "";
            string donateID = Session["DonateID"].ToString();

            if (Session["DonateID"] != null)
            {
                //SQL Statement
                string query = "SELECT * FROM Payment WHERE PaymentID = '" + donateID + "'";

                SqlConnection con = new SqlConnection(cs);
                con.Open();

                //Sql Statement
                SqlCommand cmd = new SqlCommand(query, con);

                //Execute
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    donationName = dr["Name"].ToString();
                }

                //Close connection
                dr.Close();
                con.Close();
            }

            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    string logo = Server.MapPath("invoice.png");
                    string footer = Server.MapPath("invoice-footer.png");

                    GridView1.RenderControl(hw);
                    string gridHTML = sw.ToString().Replace("\"", "'").Replace(System.Environment.NewLine, "");
                    StringBuilder sb = new StringBuilder();
                    sb.Append("<table width='100%' cellspacing='0' cellpadding='2'>");
                    sb.Append("<tr><td align='center' colspan='2'><img src='" + logo + "' width='300' height='100' /></td></tr>");
                    sb.Append("<tr><td align='center' style='background-color: #18B5F0; font-size: 20px' colspan = '2'><b>Invoice</b></td></tr>");
                    sb.Append("<tr><td colspan = '2'></td></tr>");
                    sb.Append("<tr><td><b>Name : </b>");
                    sb.Append(donationName);
                    sb.Append("</td><td align='right'><b>Date: </b>");
                    sb.Append(date);
                    sb.Append(" </td></tr>");
                    sb.Append("</table>");
                    sb.Append("<br />");
                    sb.Append("<table>");
                    sb.Append("<tr>");
                    sb.Append("<td>");
                    sb.Append(gridHTML);
                    sb.Append("</td>");
                    sb.Append("</tr>");
                    sb.Append("</table>");
                    sb.Append("<footer>");
                    sb.Append("<br /><br /><br /><br />");
                    sb.Append("<img align='center' src='" + footer + "' width='350' height='70' />");
                    sb.Append("</footer>");
                    StringReader sr = new StringReader(sb.ToString());

                    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
                        pdfDoc.Open();
                        htmlparser.Parse(sr);
                        pdfDoc.Close();
                        byte[] bytes = memoryStream.ToArray();
                        memoryStream.Close();

                        SqlConnection con = new SqlConnection(cs);
                        con.Open();
                        string emailQuery = "SELECT Email FROM Payment WHERE PaymentID ='" + donateID + "'";
                        SqlCommand emailcom = new SqlCommand(emailQuery, con);
                        string email = emailcom.ExecuteScalar().ToString();

                        MailMessage mm = new MailMessage("Fundraising Event <fundraisingevent123@gmail.com>", email);
                        //MailAddress cc1 = new MailAddress("khorms-pm19@student.tarc.edu.my");
                        //mm.CC.Add(cc1);

                        mm.Subject = "Invoice";
                        mm.Body = "Dear " + donationName + "," + "<br><br>This is your invoice." + "<br><br>Thanks <br><br>Regards,<br>Fundraising Event Team";
                        mm.Attachments.Add(new Attachment(new MemoryStream(bytes), "Invoice (" + donationName + ").pdf"));
                        mm.IsBodyHtml = true;
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = "smtp.gmail.com";
                        smtp.EnableSsl = true;
                        NetworkCredential NetworkCred = new NetworkCredential();
                        NetworkCred.UserName = "fundraisingevent123@gmail.com";
                        NetworkCred.Password = "kmfumkxjvexkthba";
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = NetworkCred;
                        smtp.Port = 587;
                        smtp.Send(mm);
                    }
                }
            }
        }

        private void changePaymentStatus()
        {
            string donateID = Session["DonateID"].ToString();

            String updateStatus = "Update Payment set PaymentStatus='Paid' where PaymentID='" + donateID + "'";
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = updateStatus;
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        void Page_Error()
        {
            // Get the exception object
            Exception ex = Server.GetLastError();

            // Clear the error so it doesn't propagate further
            Server.ClearError();

            // Display a message indicating that there might be an error
            Response.Write("<h1>Sorry, an error occurred while processing your request.</h1>");

            // Display a hyperlink that allows the user to go back
            Response.Write("<p><a href='javascript:history.back()' style='color:red; text-decoration:none;'>Go back</a></p>");
        }

    }
}