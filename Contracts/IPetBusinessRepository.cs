using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using petOwnerOneStopShop.Models;

namespace petOwnerOneStopShop.Contracts
{
    public interface IPetBusinessRepository : IRepositoryBase<PetBusiness>
    {
        PetBusiness GetPetBusiness(int petBusinessId);
        PetBusiness GetPetBusinessById(string userId);
        Task<ICollection<PetBusiness>> GetBusinessesIncludeAllAsync();
        void DeleteBusiness(IQueryable<PetBusiness> petBusiness);
        //Task FindAsync(int id);
        void CreatePetBusiness(string name, int? businessType, int address, string identityUser);
    }
}
