using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PawentsOneStopShop.Models;

namespace PawentsOneStopShop.Contracts
{
    public interface IPetBusinessRepository : IRepositoryBase<PetBusiness>
    {
        PetBusiness GetPetBusiness(int petBusinessId);
        PetBusiness GetPetBusinessById(string userId);
        ICollection<PetBusiness> GetBusinessesIncludeAll(int petBusinessId);
        Task<ICollection<PetBusiness>> GetBusinessesIncludeAllAsync();
        void DeleteBusiness(IQueryable<PetBusiness> petBusiness);
        //Task FindAsync(int id);
        void CreatePetBusiness(string name, int? businessType, int address, string identityUser);
    }
}
