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

        public void DisplayCalendar ()
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

        //app.UsegoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
        //{
        //    ClientId = "745851009726-g229larqh4c4i2mbp9k5dpk1ea5vpqa4.apps.googleusercontent.com",
        //    ClientSecret - "yZO1jC6FTnmn6WD2zE6ob0rN"
        //});

        //private static string calID = "christykyang@gmail.com"; //System.Configuration.ConfigurationManager.AppSettings["GoogleCalendarID"].ToString()
        //private static string UserId = " "; //System.Web.HttpContext.Current.User.Identity.Name
        //private static string gFolder = System.Web.HttpContext.Current.Server.MapPath("/App_Data/MyGoogleStorage");

        //public static CalendarService GetCalendarService(GoogleTokenModel GoogleTokenModelObj)
        //{
        //    CalendarService service = null;

        //    IAuthorizationCodeFlow flow = new GoogleAuthorizationCodeFlow(
        //        new GoogleAuthorizationCodeFlow.Initializer
        //        {
        //            ClientSecrets = GetClientConfiguration().Secrets,
        //            DataStore = new FileDataStore(gFolder),
        //            Scopes = new[] { CalendarService.Scope.Calendar }
        //        });

        //    var uri = /*"http://localhost:19594/GoogleCalendarRegistration.aspx";*/System.Web.HttpContext.Current.Request.Url.ToString();
        //    var code = System.Web.HttpContext.Current.Request["code"];
        //    if (code != null)
        //    {
        //        var token = flow.ExchangeCodeForTokenAsync(UserId, code,
        //            uri.Substring(0, uri.IndexOf("?")), CancellationToken.None).Result;

        //        // Extract the right state.
        //        var oauthState = AuthWebUtility.ExtracRedirectFromState(
        //            flow.DataStore, UserId, System.Web.HttpContext.Current.Request["state"]).Result;
        //        System.Web.HttpContext.Current.Response.Redirect(oauthState);
        //    }
        //    else
        //    {
        //        var result = new AuthorizationCodeWebApp(flow, uri, uri).AuthorizeAsync(UserId, CancellationToken.None).Result;
        //        if (result.RedirectUri != null)
        //        {
        //            // Redirect the user to the authorization server.
        //            System.Web.HttpContext.Current.Response.Redirect(result.RedirectUri);
        //            //var page = System.Web.HttpContext.Current.CurrentHandler as Page;
        //            //page.ClientScript.RegisterClientScriptBlock(page.GetType(),
        //            //    "RedirectToGoogleScript", "window.top.location = '" + result.RedirectUri + "'", true);
        //        }
        //        else
        //        {
        //            // The data store contains the user credential, so the user has been already authenticated.
        //            service = new CalendarService(new BaseClientService.Initializer
        //            {
        //                ApplicationName = "My ASP.NET Google Calendar App",
        //                HttpClientInitializer = result.Credential
        //            });
        //        }
        //    }

        //    return service;
        //}

        //public static GoogleClientSecrets GetClientConfiguration()
        //{
        //    using (var stream = new FileStream(gFolder + @"\client_secret.json", FileMode.Open, FileAccess.Read))
        //    {
        //        return GoogleClientSecrets.Load(stream);
        //    }
        //}

        //public static bool AddUpdateDeleteEvent(List<CalendarEvent> EventModelList, List<GoogleTokenModel> GoogleTokenModelList, double TimeOffset)
        //{
        //    //Get the calendar service for a user to add/update/delete events
        //    CalendarService calService = GetCalendarService(GoogleTokenModelList[0]);

        //    if (EventModelList != null && EventModelList.Count > 0)
        //    {
        //        foreach (CalendarEvent GoogleCalendarAppointmentModelObj in EventModelList)
        //        {
        //            EventsResource er = new EventsResource(calService);
        //            string ExpKey = "EventID";
        //            string ExpVal = GoogleCalendarAppointmentModelObj.Id.ToString();

        //            var queryEvent = er.List(calID);
        //            queryEvent.SharedExtendedProperty = ExpKey + "=" + ExpVal; //"EventID=9999"
        //            var EventsList = queryEvent.Execute();

        //            //to restrict the appointment for specific staff only
        //            //Delete this appointment from google calendar
        //            if (GoogleCalendarAppointmentModelObj.Delete == true)
        //            {
        //                string FoundEventID = String.Empty;
        //                foreach (Event evItem in EventsList.Items)
        //                {
        //                    FoundEventID = evItem.Id;
        //                    if (!String.IsNullOrEmpty(FoundEventID))
        //                    {
        //                        er.Delete(calID, FoundEventID).Execute();
        //                    }
        //                }
        //                return true;
        //            }
        //            //Add if not found OR update if appointment already present on google calendar
        //            else
        //            {
        //                Event eventEntry = new Event();

        //                EventDateTime StartDate = new EventDateTime();
        //                EventDateTime EndDate = new EventDateTime();
        //                StartDate.Date = GoogleCalendarAppointmentModelObj.StartTime.ToString("yyyy-MM-dd"); //"2014-11-17";
        //                EndDate.Date = StartDate.Date; //GoogleCalendarAppointmentModelObj.EventEndTime

        //                //Always append Extended Property whether creating or updating event
        //                Event.ExtendedPropertiesData exp = new Event.ExtendedPropertiesData();
        //                exp.Shared = new Dictionary<string, string>();
        //                exp.Shared.Add(ExpKey, ExpVal);

        //                eventEntry.Summary = GoogleCalendarAppointmentModelObj.Title;
        //                eventEntry.Start = StartDate;
        //                eventEntry.End = EndDate;
        //                eventEntry.Location = GoogleCalendarAppointmentModelObj.Location;
        //                eventEntry.Description = GoogleCalendarAppointmentModelObj.Details;
        //                eventEntry.ExtendedProperties = exp;

        //                string FoundEventID = String.Empty;
        //                foreach (var evItem in EventsList.Items)
        //                {
        //                    FoundEventID = evItem.Id;
        //                    if (!String.IsNullOrEmpty(FoundEventID))
        //                    {
        //                        //Update the event
        //                        er.Update(eventEntry, calID, FoundEventID).Execute();
        //                    }
        //                }

        //                if (String.IsNullOrEmpty(FoundEventID))
        //                {
        //                    //create the event
        //                    er.Insert(eventEntry, calID).Execute();
        //                }

        //                return true;
        //            }
        //        }
        //    }

        //    return false;
        //}
    }
}
