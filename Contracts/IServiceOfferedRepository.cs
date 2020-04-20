using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using petOwnerOneStopShop.Models;

namespace petOwnerOneStopShop.Contracts
{
    public interface IServiceOfferedRepository : IRepositoryBase<ServiceOffered>
    {
		ICollection<ServiceOffered> GetServicesOfferedByProvider(int petBusinessId);
		ICollection<ServiceOffered> GetServicesOfferedIncludeAll();
		ICollection<ServiceOffered> GetServicesOfferedIncludeAll(int id);
		Task<ICollection<ServiceOffered>> GetServicesOfferedIncludeAllAsync();
		Task<ICollection<ServiceOffered>> GetServicesOfferedIncludeAllAsync(int petBusinessId);
		ServiceOffered GetServiceOffered(int id);
		void CreateServiceOffered(string cost, PetBusiness petBusiness, Service service);
		ServiceOffered GetServiceOfferedByIdIncludeAll(int serviceOfferedId);
	}
}
