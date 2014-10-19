using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Models
{
    public class Project
    {
        public string ProjectName { get; set; }

        public List<Task> ProjectTasks { get; set; }
    }
}