using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using petOwnerOneStopShop.Contracts;
using petOwnerOneStopShop.Models;

namespace petOwnerOneStopShop.Data
{
    public class PetProfileRepository : RepositoryBase<PetProfile>, IPetProfileRepository
    {
        public PetProfileRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {

        }
        public void CreatePet(PetProfile pet) => Create(pet);
        public PetProfile GetPetById(int? petId) => FindByCondition(p => p.Id == petId).FirstOrDefault();
		public PetProfile GetPetByIdIncludeAll(int petId)
		{
			return FindByCondition(p => p.Id == petId).Include(p => p.PetOwner)
				.Include(t => t.PetType).FirstOrDefault();
		}
		public ICollection<PetProfile> GetPetsTiedToOwner(int petOwnerId) => FindByCondition(o => o.PetOwnerId == petOwnerId).ToList();
		public ICollection<PetProfile> GetPetsByOwnerId(int id)
		{
			return FindAll().Where(o => o.PetOwnerId == id).ToList();
		}
		public async Task<ICollection<PetProfile>> GetPetsByOwnerIdAndIncludeAll(int petOwnerId)
		{
			return await FindAll()
				.Include(p => p.PetType)
				.Where(o => o.PetOwnerId == petOwnerId).ToListAsync();
		}
		public ICollection<PetProfile> GetPetAndIncludeAll()
		{
			return FindAll().Include(p => p.PetOwner).Include(p => p.PetType).ToList();
		}
		public ICollection<PetProfile> GetPetProfileAndIncludeAll(int id)
		{
			return FindAll().Include(p => p.PetOwner).Include(p => p.PetType).Where(p => p.Id == id).ToList();
		}
		public async Task<PetProfile> GetPetByIdIncludeAllAsync(int? petId)
		{
			return await FindByCondition(m => m.Id == petId).Include(p => p.PetOwner)
				.Include(t => t.PetType).FirstOrDefaultAsync();
		}

		public async Task<ICollection<PetProfile>> GetPetIncludeAll()
		{
			return await FindAll().Include(o => o.PetOwner)
								  .Include(t => t.PetType).ToListAsync();
		}
		public void CreatePetProfile(PetOwner petOwner, PetType petType, string name, int age, bool? isMale, bool? isAdopted, string picture)
		{
			PetProfile petProfile = new PetProfile();
			petProfile.PetOwnerId = petOwner.Id;
			petProfile.PetTypeId = petType.Id;
			petProfile.Name = name;
			petProfile.Age = age;
			petProfile.IsMale = isMale;
			petProfile.IsAdopted = isAdopted;
			petProfile.ProfilePicture = picture;
			Create(petProfile);
		}
	}
}
