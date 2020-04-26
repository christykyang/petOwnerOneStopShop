using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PawentsOneStopShop.Contracts;
using PawentsOneStopShop.Models;

namespace PawentsOneStopShop.Data
{
    public class ServiceRepository : RepositoryBase<Service>, IServiceRepository
    {
        public ServiceRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {

        }
        public ICollection<Service> GetAllServices()
        {
            return FindAll().ToList();
        }
    }
}

