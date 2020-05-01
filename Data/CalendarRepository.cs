using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PawentsOneStopShop.Contracts;
using PawentsOneStopShop.Models;

namespace PawentsOneStopShop.Data
{
    public class CalendarRepository : RepositoryBase<ObjectCalendar>, ICalendarRepository
    {
        public CalendarRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {

        }
        public void CreateCalendar(ObjectCalendar calendar) => Create(calendar);
        public ObjectCalendar GetCalenderByIdentityUser(string userId)
        {
            return FindByCondition(c => c.IdentityUserId == userId).FirstOrDefault();
        }
    }
}
