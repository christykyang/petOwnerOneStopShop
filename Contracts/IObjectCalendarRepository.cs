﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PawentsOneStopShop.Models;

namespace PawentsOneStopShop.Contracts
{
    public interface IObjectCalendarRepository : IRepositoryBase<ObjectCalendar>
    {
        void CreateCalendar(ObjectCalendar objectCalendar);
        ObjectCalendar GetCalenderByIdentityUser(string userId);
    }
}
