using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PawentsOneStopShop.Models;

namespace PawentsOneStopShop.Contracts
{
    public interface IPetProfileRepository : IRepositoryBase<PetProfile>
    {
		void CreatePet(PetProfile pet);
		PetProfile GetPetById(int? petId);
		PetProfile GetPetByIdIncludeAll(int petId);
		Task<PetProfile> GetPetByIdIncludeAllAsync(int? petId);
		Task<ICollection<PetProfile>> GetPetIncludeAll();
		void CreatePetProfile(int? petOwnerId, int? petTypeId, string name, int age, bool? isMale, bool? isAdopted, string picture);
		ICollection<PetProfile> GetPetAndIncludeAll();
		ICollection<PetProfile> GetPetsTiedToOwner(int petOwnerId);
		ICollection<PetProfile> GetPetsByOwnerId(int id);
		Task<ICollection<PetProfile>> GetPetsByOwnerIdAndIncludeAll(int petOwnerId);
	}
}
