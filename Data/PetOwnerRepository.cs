using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PawentsOneStopShop.Contracts;
using PawentsOneStopShop.Models;

namespace PawentsOneStopShop.Data
{
    public class PetOwnerRepository : RepositoryBase<PetOwner>, IPetOwnerRepository
    {
        public PetOwnerRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {

        }
        public PetOwner GetPetOwner(int petOwnerId) => FindByCondition(i => i.Id == petOwnerId).SingleOrDefault();
        public PetOwner GetPetOwnerById(string userId) => FindByCondition(p => p.IdentityUserId == userId).FirstOrDefault();
        public void Remove(PetOwner petOwner) => FindByCondition(o => o.Id == petOwner.Id).FirstOrDefault();
        public void CreatePetOwner(string name, int addressId, string identityUser)
        {
            PetOwner petOwner = new PetOwner();
            petOwner.Name = name;
            petOwner.AddressId = addressId;
            petOwner.IdentityUserId = identityUser;
            Create(petOwner);
        }
    }
}
