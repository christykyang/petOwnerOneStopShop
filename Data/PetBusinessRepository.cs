using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using petOwnerOneStopShop.Contracts;
using petOwnerOneStopShop.Models;

namespace petOwnerOneStopShop.Data
{
    public class PetBusinessRepository : RepositoryBase<PetBusiness>, IPetBusinessRepository
    {
        public PetBusinessRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {

        }
        public PetBusiness GetPetBusiness(int petBusinessId) => FindByCondition(i => i.Id == petBusinessId).SingleOrDefault();
        public PetBusiness GetPetBusinessById(string userId) => FindByCondition(p => p.IdentityUserId == userId).FirstOrDefault();

        private void Delete(IQueryable<PetBusiness> petBusiness)
        {
            throw new NotImplementedException();
        }
    }
}
