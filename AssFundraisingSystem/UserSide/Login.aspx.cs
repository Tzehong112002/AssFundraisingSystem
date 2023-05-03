﻿using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using BCrypt.Net;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;

namespace AssFundraisingSystem.UserSide
{
    public partial class Login : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["MYConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed4_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string secretKey = "6LfJUNslAAAAADSC7im1g7ZZWAEfqZF1j6Z5yaOY";
            string captchaResponse = Request.Form["g-recaptcha-response"];
            bool captchaValid = VerifyCaptcha(captchaResponse, secretKey);

            if (Page.IsValid && captchaValid)
            {
                int RowCount;
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                string str = "SELECT * FROM Account WHERE Username=@Username";
                SqlCommand cmd = new SqlCommand(str, con);
                cmd.Parameters.AddWithValue("@Username", username);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                RowCount = dt.Rows.Count;

                if (RowCount > 0)
                {
                    string hashedPasswordFromDatabase = dt.Rows[0]["Password"].ToString();

                    if (BCrypt.Net.BCrypt.Verify(password, hashedPasswordFromDatabase))
                    {
                        string status = "No";

                        if (dt.Rows[0]["BanStatus"].ToString().Trim() == status)
                        {
                            con.Close();
                            Session["UserID"] = dt.Rows[0]["UserID"].ToString();
                            Response.Redirect("program.aspx");
                        }
                        else
                        {
                            Response.Write("<script>alert('Your account has been banned by the admin.')</script>");
                        }
                    }
                    else
                    {
                        lblMessage.Visible = true;
                        lblMessage.Text = "Invalid Username and Password. Please try again!";
                    }
                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "Invalid Username and Password. Please try again!";
                }

                con.Close();
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Invalid reCAPTCHA. Please try again!";
            }
        }

        private bool VerifyCaptcha(string captchaResponse, string secretKey)
        {
            bool result = false;

            try
            {
                string apiUrl = "https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}";
                string requestUri = string.Format(apiUrl, secretKey, captchaResponse);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUri);
                request.Timeout = 5000;
                using (WebResponse response = request.GetResponse())
                {
                    using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
                    {
                        JObject jResponse = JObject.Parse(streamReader.ReadToEnd());
                        bool success = (bool)jResponse.SelectToken("success");
                        result = success;
                    }
                }
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }
    }
}
