using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webcsm_caldemo.Models
{
    public class CalendarEvent
    {
        public string Title { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Summary { get; set; }
    }
}