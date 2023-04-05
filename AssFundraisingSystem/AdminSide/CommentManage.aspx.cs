using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AssFundraisingSystem.AdminSide
{
    public partial class CommentManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEditComment_Click(object sender, EventArgs e)
        {
            Response.Redirect("CommentEdit.aspx");
        }

        protected void btnDelComment_Click(object sender, EventArgs e)
        {
            /*Delete function*/
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("CommentAdd.aspx");
        }
    }
}