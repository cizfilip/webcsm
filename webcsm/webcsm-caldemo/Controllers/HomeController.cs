using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webcsm_caldemo.Models;
using webcsm_caldemo.ViewModels;

namespace webcsm_caldemo.Controllers
{
    public class HomeController : Controller
    {
        GoogleCalendar googleCalendar = new GoogleCalendar();
        //
        // GET: /Home/

        public ActionResult Index()
        {
            
            var viewModel = new GoogleCalendarViewModel
            {
                UserCalendars = googleCalendar.GetUserCalendars(),
                UserName = googleCalendar.GetUserName()
            };
            
            return View(viewModel);
        }

        public ActionResult Events(string calendar, string feed)
        {
            var viewModel = new GoogleCalendarEventsViewModel
            {
                CalendarName = calendar,
                Events = googleCalendar.GetAllEvents(feed)
            };

            return View(viewModel);
        }

    }
}
