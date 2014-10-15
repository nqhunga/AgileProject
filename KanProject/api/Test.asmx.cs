using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace KanProject.api
{
    /// <summary>
    /// Summary description for Test
    /// </summary>
    [System.Web.Script.Services.ScriptService]
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Test : System.Web.Services.WebService
    {
        [WebMethod]
        public object HelloWorld()
        {
            return new { Message = "Hello World" };
        }

        [System.Web.Services.WebMethod]
        public object GetAllProducts()
        {
            return new { Message = "Success!" };
        }
    }
}
