using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PawentsOneStopShop.Contracts;
using PawentsOneStopShop.Models;

namespace PawentsOneStopShop.Data
{
    public class ServiceOfferedRepository : RepositoryBase<ServiceOffered>, IServiceOfferedRepository
    {
        public ServiceOfferedRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        { }
		public ICollection<ServiceOffered> GetServicesOfferedByPetBusiness(int petBusinessId)
		{
			return FindByCondition(s => s.PetBusinessId == petBusinessId).ToList();
		}
		public async Task<ICollection<ServiceOffered>> GetServiceOfferedIncludeAllAsync()
		{
			return await FindAll()
				.Include(b => b.PetBusiness)
				.Include(s => s.Service).ToListAsync();
		}
		public ICollection<ServiceOffered> GetServicesOfferedIncludeAll()
		{
			return FindAll().Include(s => s.PetBusiness).Include(s => s.Service).ToList();
		}
		public ICollection<ServiceOffered> GetServicesOfferedIncludeAll(int id)
		{
			return FindAll().Include(s => s.PetBusiness).Include(s => s.Service).Where(s => s.Id == id).ToList();
		}
		public async Task<ICollection<ServiceOffered>> GetServicesOfferedIncludeAllAsync()
		{
			return await FindAll()
				.Include(b => b.PetBusiness)
				.Include(s => s.Service).ToListAsync();
		}
		public async Task<ICollection<ServiceOffered>> GetServicesOfferedIncludeAllAsync(int petBusinessId)
		{
			return await FindAll()
				.Include(b => b.PetBusiness)
				.Include(s => s.Service).Where(s => s.PetBusinessId == petBusinessId).ToListAsync();
		}
		public ServiceOffered GetServiceOffered(int id)
		{
			return FindByCondition(s => s.Id == id).FirstOrDefault();
		}
		public ServiceOffered GetServiceOfferedByIdIncludeAll(int serviceOfferedId)
		{
			return FindByCondition(s => s.Id == serviceOfferedId).Include(p => p.PetBusinessId)
				.Include(b => b.PetBusiness)
				.Include(s => s.Service).FirstOrDefault();
		}
		public void CreateServiceOffered(string cost, int petBusinessId, int serviceId, string service)
		{
			ServiceOffered serviceOffered = new ServiceOffered();
			serviceOffered.Cost = cost;
			serviceOffered.PetBusinessId = petBusinessId;
			serviceOffered.ServiceId = serviceId;
			serviceOffered.
			Create(serviceOffered);
		}
	}
}
