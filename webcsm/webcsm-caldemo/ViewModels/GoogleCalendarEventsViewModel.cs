using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webcsm_caldemo.Models;

namespace webcsm_caldemo.ViewModels
{
    public class GoogleCalendarEventsViewModel
    {
        public List<CalendarEvent> Events { get; set; }
        public string CalendarName { get; set; }
    }
}