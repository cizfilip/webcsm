using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace webcsm.Models
{
    [Bind(Include = "Name,Description,GroupId")]
    [MetadataType(typeof(Person_Validation))]
    public partial class Project
    {

    }

    
    public class Person_Validation
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(30, ErrorMessage = "Name may not be longer than 30 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(256, ErrorMessage = "Description may not be longer than 256 characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Group is required")]
        public Int32 GroupId { get; set; }

      
    }
}