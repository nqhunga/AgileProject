using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Models;
namespace KanProject
{
    public partial class KanProject : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User user = (User)Session["User"];

            if (user == null || String.IsNullOrEmpty(user.UserName))
                Response.Redirect("Login.aspx");
        }
    }
}