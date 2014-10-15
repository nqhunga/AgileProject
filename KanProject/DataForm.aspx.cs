using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;
using DAL.Models;
using DAL;

namespace KanProject
{
    public partial class DataForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User user = (User)Session["User"];

            if (user == null || String.IsNullOrEmpty(user.UserName))
                Response.Redirect("Login.aspx");

            if (!Page.IsPostBack)
            {
                DBConnection dbConnection = OrdersDAL.GetOrders(user);

                OleDbDataAdapter myAdapter = new OleDbDataAdapter();
                DataSet myDataSet = new DataSet();

                myAdapter.SelectCommand = dbConnection.Cmds[0];
                myAdapter.Fill(myDataSet, "Orders");
                GridView1.DataSource = myDataSet;
                GridView1.DataBind();
            }
        }
    }
}