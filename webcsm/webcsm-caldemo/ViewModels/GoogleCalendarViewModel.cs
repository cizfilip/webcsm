using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webcsm_caldemo.Models;

namespace webcsm_caldemo.ViewModels
{
    public class GoogleCalendarViewModel
    {
        public List<Calendar> UserCalendars { get; set; }
        public string UserName { get; set; }
    }
}