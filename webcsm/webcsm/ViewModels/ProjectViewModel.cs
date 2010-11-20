using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webcsm.Models;
using System.Web.Mvc;

namespace webcsm.ViewModels
{
    public class ProjectViewModel
    {
        public List<GroupWithProjects> Groups { get; set; }
    }

    public class GroupWithProjects
    {
        public Group Group { get; set; }
        public List<Project> Projects { get; set; }
        
    }
}