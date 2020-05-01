using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PawentsOneStopShop.Models;

namespace PawentsOneStopShop.Contracts
{
    public interface IObjectEventRepository : IRepositoryBase<ObjectEvent>
    {
        void CreateEvent(ObjectEvent _event);
        ObjectEvent GetEventByAllProperties(string? title, string? location, string? details, DateTime? date, DateTime? startTime, DateTime? endTime, int hostCalendarId);
        ICollection<ObjectEvent> GetEventsTiedToCalenderId(int calendarId);
    }

}
