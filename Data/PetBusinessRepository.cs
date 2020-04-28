using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Bson;
using PawentsOneStopShop.Contracts;
using PawentsOneStopShop.Models;

namespace PawentsOneStopShop.Data
{
    public class PetBusinessRepository : RepositoryBase<PetBusiness>, IPetBusinessRepository
    {
        public PetBusinessRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {

        }
        public PetBusiness GetPetBusiness(int petBusinessId) => FindByCondition(i => i.Id == petBusinessId).SingleOrDefault();
        public PetBusiness GetPetBusinessById(string userId) => FindByCondition(p => p.IdentityUserId == userId).FirstOrDefault();
        public ICollection<PetBusiness> GetBusinessesIncludeAll(int petBusinessId)
        {
            return FindAll()
                .Include(t => t.BusinessType)
                .Include(a => a.Address).ToList();
        }
        public async Task<ICollection<PetBusiness>> GetBusinessesIncludeAllAsync()
        {
            return await FindAll()
                .Include(t => t.BusinessType)
                .Include(a => a.Address).ToListAsync();
        }
        public void DeleteBusiness(IQueryable<PetBusiness> petBusiness)
        {
            throw new NotImplementedException();
        }
        public void CreatePetBusiness(string name, int? businessTypeId, int addressId, string identityUser)
        {
            PetBusiness petBusiness = new PetBusiness();
            petBusiness.Name = name;
            petBusiness.BusinessTypeId = businessTypeId;
            petBusiness.AddressId = addressId;
            petBusiness.IdentityUserId = identityUser;
            Create(petBusiness);
        }
    }
}
