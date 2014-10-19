using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Models;
using System.Linq;

namespace CustomControls
{
    [ToolboxData("<{0}:ServerControl1 runat=server></{0}:Kanboard>")]
    public class Kanboard : WebControl
    {
        public int NumCols { get; set; }

        public Project Project {get; set;}


        protected override void RenderContents(HtmlTextWriter output)
        {
            if (this.Project != null)
            {
                output.AddAttribute(HtmlTextWriterAttribute.Id, this.ID);
                output.AddAttribute("class", "kanboard");
                output.RenderBeginTag("table");
                output.RenderBeginTag("tr");
                for (var i = 1; i <= NumCols; i++)
                {
                    output.RenderBeginTag("th");
                    output.Write("Column " + i);
                    output.RenderEndTag();
                }
                output.RenderEndTag();
                output.RenderBeginTag("tr");

                for (var i = 1; i <= NumCols; i++)
                {
                    output.AddAttribute("class", "column");
                    output.AddAttribute("data-col-index", i.ToString());
                    output.RenderBeginTag("td");

                    foreach (var task in this.Project.ProjectTasks.OrderBy(t => t.TaskOrder))
                    {
                        if (task.TaskColumn == i)
                        {
                            output.AddAttribute("class", "task");
                            output.AddAttribute("data-task-id", task.TaskId.ToString());
                            output.RenderBeginTag("div");
                            output.Write(task.TaskName);
                            output.RenderEndTag();
                        }
                    }
                    output.RenderEndTag();
                }
                output.RenderEndTag();
                output.RenderEndTag();
            }
        }

        protected override void Render(HtmlTextWriter writer)
        {
            this.RenderContents(writer);
        }
    }
}
