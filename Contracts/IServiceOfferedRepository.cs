using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PawentsOneStopShop.Models;

namespace PawentsOneStopShop.Contracts
{
    public interface IServiceOfferedRepository : IRepositoryBase<ServiceOffered>
    {
		ICollection<ServiceOffered> GetServicesOfferedByPetBusiness(int petBusinessId);
		ICollection<ServiceOffered> GetServicesOfferedIncludeAll();
		ICollection<ServiceOffered> GetServicesOfferedIncludeAll(int id);
		Task<ICollection<ServiceOffered>> GetServicesOfferedIncludeAllAsync();
		Task<ICollection<ServiceOffered>> GetServicesOfferedIncludeAllAsync(int petBusinessId);
		ServiceOffered GetServiceOffered(int id);
		void CreateServiceOffered(string cost, int petBusinessId, int serviceId);
		ServiceOffered GetServiceOfferedByIdIncludeAll(int serviceOfferedId);
	}
}
