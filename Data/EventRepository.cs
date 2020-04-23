using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using petOwnerOneStopShop.Contracts;
using petOwnerOneStopShop.Models;

namespace petOwnerOneStopShop.Data
{
    public class EventRepository : RepositoryBase<CalendarEvent>, IEventRepository
    {
        public EventRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {

        }
        public void CreateEvent(CalendarEvent _event) => Create(_event);
    }
}
