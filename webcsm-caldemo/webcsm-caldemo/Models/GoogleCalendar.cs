using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Google.GData.Calendar;
using Google.GData.Client;

namespace webcsm_caldemo.Models
{
    public class GoogleCalendar
    {
        private const string GoogleUsername = "cizfilip@fel.cvut.cz";
        private const string GooglePassword = "";
        
        private const string GoogleFeedsUriDefault = "http://www.google.com/calendar/feeds/default";

        private CalendarService calendarService;
        private string userName;
        private string userPassword;

        public GoogleCalendar()
        {
            this.userName = GoogleUsername;
            this.userPassword = GooglePassword;
            calendarService = new CalendarService("webcsm");
            calendarService.setUserCredentials(userName, userPassword);
        }

        public string GetUserName() 
        {
            return userName;
        }

        public List<Calendar> GetUserCalendars()
        {
            FeedQuery query = new FeedQuery();
            query.Uri = new Uri(GoogleFeedsUriDefault);

            // Tell the service to query:
            AtomFeed calFeed = calendarService.Query(query);

            List<Calendar> result = new List<Calendar>();
            foreach (var item in calFeed.Entries)
            {
                var calID = item.SelfUri.ToString().Split(new char[] {'/'});
                var calendar = new Calendar
                {
                    Title = item.Title.Text,
                    CalendarID = calID.Last()
                };
                result.Add(calendar);
            }

            return result;
        }


        public List<CalendarEvent> GetAllEvents(string calID)
        {
            EventQuery myQuery = new EventQuery(String.Format("https://www.google.com/calendar/feeds/{0}/private/full",calID));
            EventFeed myResultsFeed = calendarService.Query(myQuery) as EventFeed;
            List<CalendarEvent> result = new List<CalendarEvent>();
            
            foreach (EventEntry item in myResultsFeed.Entries)
            {
                var calendarEvent = new CalendarEvent
                {
                    Title = item.Title.Text,
                    Summary = item.Content.Content,
                    StartTime = item.Times.First().StartTime.ToString(),
                    EndTime = item.Times.First().EndTime.ToString()                    
                };
                
                result.Add(calendarEvent);
            }

            return result;
        }
    }
}