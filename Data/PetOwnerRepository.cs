using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using petOwnerOneStopShop.Contracts;
using petOwnerOneStopShop.Models;

namespace petOwnerOneStopShop.Data
{
    public class PetOwnerRepository : RepositoryBase<PetOwner>, IPetOwnerRepository
    {
        public PetOwnerRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {

        }
        public PetOwner GetPetOwner(int petOwnerId) => FindByCondition(i => i.Id == petOwnerId).SingleOrDefault();
        public PetOwner GetPetOwnerById(string userId) => FindByCondition(p => p.IdentityUserId == userId).FirstOrDefault();
    }
}
