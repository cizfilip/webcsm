using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace webcsm.Models
{
    [Bind(Include = "Name")]
    [MetadataType(typeof(Group_Validation))]
    public partial class Group
    {

    }

    
    public class Group_Validation
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(30, ErrorMessage = "Name may not be longer than 30 characters")]
        public string Name { get; set; }
    }
}