using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using petOwnerOneStopShop.Models;

namespace petOwnerOneStopShop.Contracts
{
    public interface IPetProfileRepository : IRepositoryBase<PetProfile>
    {
		void CreatePet(PetProfile pet);
		PetProfile GetPetById(int? petId);
		PetProfile GetPetByIdIncludeAll(int? petId);
		Task<PetProfile> GetPetByIdIncludeAllAsync(int? petId);
		Task<ICollection<PetProfile>> GetPetIncludeAll();
	}
}
