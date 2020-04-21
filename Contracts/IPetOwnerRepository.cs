using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using petOwnerOneStopShop.Models;

namespace petOwnerOneStopShop.Contracts
{
    public interface IPetOwnerRepository : IRepositoryBase<PetOwner>
    {
        PetOwner GetPetOwner(int providerId);
        PetOwner GetPetOwnerById(string userId);
        void Remove(PetOwner petOwner);
    }
}
