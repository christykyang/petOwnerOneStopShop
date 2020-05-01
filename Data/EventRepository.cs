using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PawentsOneStopShop.Contracts;
using PawentsOneStopShop.Models;

namespace PawentsOneStopShop.Data
{
    public class EventRepository : RepositoryBase<ObjectEvent>, IObjectEventRepository
    {
        public EventRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {

        }
        public void CreateEvent(ObjectEvent _event) => Create(_event);
        public ObjectEvent GetEventByAllProperties(string? title, string? location, string? details, DateTime? date, DateTime? startTime, DateTime? endTime, int hostCalendarId)
        {
            return FindByCondition(i => i.Title == title && i.Location == location && i.Details == details && i.Date == date && i.StartTime == startTime && i.EndTime == endTime && i.ObjectCalendarId == hostCalendarId).FirstOrDefault();
        }
        public ICollection<ObjectEvent> GetEventsTiedToCalenderId(int calendarId)
        {
            return FindAll().Where(e => e.ObjectCalendarId == calendarId).ToList();
        }
    }
}
