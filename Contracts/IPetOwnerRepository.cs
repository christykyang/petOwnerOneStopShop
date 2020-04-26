using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PawentsOneStopShop.Models;

namespace PawentsOneStopShop.Contracts
{
    public interface IPetOwnerRepository : IRepositoryBase<PetOwner>
    {
        PetOwner GetPetOwner(int providerId);
        PetOwner GetPetOwnerById(string userId);
        void Remove(PetOwner petOwner);
        void CreatePetOwner(string name, int addressId, string identityUser);
    }
}
