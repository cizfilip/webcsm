using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;

namespace webcsm.Models
{
    public class ProjectFormViewModel
    {
        public Project Project { get; set; }
        //[DisplayName("Select the group in which the project will create")]
        public SelectList UserGroups { get; set; }
       
    }
}