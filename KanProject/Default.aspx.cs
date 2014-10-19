using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Models;
using DAL;

namespace KanProject
{
    public partial class Default : System.Web.UI.Page
    {
        public int numCols;
        protected void Page_Load(object sender, EventArgs e)
        {
            // THIS IS TEST DATA
            numCols = 5;

            Kanboard.Project = ProjectsDAL.GetProject();
        }
    }
}