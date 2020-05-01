using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
//using System.Web.UI;
using System.IO;
using System.Threading;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Web;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using PawentsOneStopShop.Models;
using Microsoft.AspNetCore.Identity;
using PawentsOneStopShop.Contracts;
using Google.Apis.Auth;
using Calendar = Google.Apis.Calendar.v3.Data.Calendar;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace PawentsOneStopShop.Services
{
    public class CalendarApi : ICalendarRequest
    {
        private IRepositoryWrapper _repo;
        public CalendarApi(IRepositoryWrapper repo)
        {
            _repo = repo;
        }

        static string[] Scopes = { CalendarService.Scope.Calendar, CalendarService.Scope.CalendarEvents };
        static string ApplicationName = "Google Calendar API .NET Quickstart";

        //public string GetMyCalendar()
        //{
        //    //string api = "https://www.googleapis.com/calendar/v3/users/me/calendarList/calendarId"
        //    Calendar calender = Google.Apis()
        //}

        //public async Task<Event> CreateEvent()
        //{
        //    var calendar = 
        //}

        public void DisplayCalendar()
        {
            UserCredential credential;

            using (var stream =
                new FileStream("google.CalendarAPIsCredentials.json", FileMode.Open, FileAccess.Read))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            // Create Google Calendar API service.
            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            // Define parameters of request.
            EventsResource.ListRequest request = service.Events.List("primary");
            request.TimeMin = DateTime.Now;
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.MaxResults = 10;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            // List events.
            Events events = request.Execute();
            Console.WriteLine("Upcoming events:");
            if (events.Items != null && events.Items.Count > 0)
            {
                foreach (var eventItem in events.Items)
                {
                    string when = eventItem.Start.DateTime.ToString();
                    if (String.IsNullOrEmpty(when))
                    {
                        when = eventItem.Start.Date;
                    }
                    Console.WriteLine("{0} ({1})", eventItem.Summary, when);
                }
            }
            else
            {
                Console.WriteLine("No upcoming events found.");
            }
            Console.Read();
        }

        //public void CreateEvent()
        //{
        //    var ev = new Event();
        //    EventDateTime start = new EventDateTime();
        //    start.DateTime = new DateTime(2019, 3, 11, 10, 0, 0);

        //    EventDateTime end = new EventDateTime();
        //    end.DateTime = new DateTime(2019, 3, 11, 10, 30, 0);


        //    ev.Start = start;
        //    ev.End = end;
        //    ev.Summary = "New Event";
        //    ev.Description = "Description...";

        //    var calendarId = "primary";
        //    Event recurringEvent = service.Events.Insert(ev, calendarId).Execute();
        //    Console.WriteLine("Event created: %s\n", ev.HtmlLink);
        //}


    }
}
