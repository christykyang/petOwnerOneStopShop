using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using petOwnerOneStopShop.Contracts;
using petOwnerOneStopShop.Models;

namespace petOwnerOneStopShop.Data
{
    public class CalendarRepository : RepositoryBase<Calendar>, ICalendarRepository
    {
        public CalendarRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {

        }
        public void CreateCalendar(Calendar calendar) => Create(calendar);
    }
}
