﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PawentsOneStopShop.Models;

namespace PawentsOneStopShop.Contracts
{
    public interface IEventRepository : IRepositoryBase<ObjectEvent>
    {
        void CreateEvent(ObjectEvent _event);
    }
}
