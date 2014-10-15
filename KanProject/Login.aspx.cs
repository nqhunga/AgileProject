using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using DAL.Models;

namespace KanProject
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {

                var userName = UserName.Text;
                var passWord = PassWord.Text;

                if (!String.IsNullOrEmpty(userName) && !String.IsNullOrEmpty(passWord))
                {
                    User user = UsersDAL.Login(userName, passWord);
                    if (user != null)
                    {
                        Session["User"] = user;
                        Response.Redirect("DataForm.aspx");
                    }
                    else
                        ErrorPanel.Visible = true;
                }

            }
        }
    }
}