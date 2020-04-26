using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PawentsOneStopShop.Contracts;
using PawentsOneStopShop.Models;

namespace PawentsOneStopShop.Data
{
    public class EventRepository : RepositoryBase<ObjectEvent>, IEventRepository
    {
        public EventRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {

        }
        public void CreateEvent(ObjectEvent _event) => Create(_event);
    }
}
