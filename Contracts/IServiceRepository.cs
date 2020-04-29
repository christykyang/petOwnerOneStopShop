using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PawentsOneStopShop.Models;

namespace PawentsOneStopShop.Contracts
{
    public interface IServiceRepository : IRepositoryBase<Service>
    {
        ICollection<Service> GetAllServices();
        Task<ICollection<Service>> GetAllServicesAsync();
    }
}
