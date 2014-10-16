using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace KanProject.api
{
    /// <summary>
    /// Summary description for Projects
    /// </summary>
    [System.Web.Script.Services.ScriptService]
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Projects : System.Web.Services.WebService
    {
        [WebMethod]
        public object SaveProject()
        {
            return new { message = "SAVING NOT YET IMPLEMENTED" };
        }

        [WebMethod]
        public object CheckProject()
        {
            return new { message = "CHECKING NOT YET IMPLEMENTED" };
        }
    }
}
