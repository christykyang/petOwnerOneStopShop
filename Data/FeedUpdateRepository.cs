using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PawentsOneStopShop.Contracts;
using PawentsOneStopShop.Models;

namespace PawentsOneStopShop.Data
{
    public class FeedUpdateRepository : RepositoryBase<FeedUpdate>, IFeedUpdateRepository
    {
        public FeedUpdateRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {

        }
        public async Task<ICollection<FeedUpdate>> FindUpdatesByPetBusinessIncludeAll(string userId)
        {
            return await FindAll().Where(f => f.PetBusiness.IdentityUserId == userId).ToListAsync();
        }
        public async Task<ICollection<FeedUpdate>> FindUpdatesByPetBusinessIdIncludeAllAsync(int id)
        {
            return await FindAll().Where(f => f.PetBusinessId == id).ToListAsync();
        }

        public ICollection<FeedUpdate> FindUpdatesByPetBusinessIdIncludeAll(int id)
        {
            return FindAll().Where(f => f.PetBusinessId == id).ToList();
        }
        public ICollection<FeedUpdate> FindUpdatesByNewsFeedId(int id)
        {
            return FindAll().Where(f => f.PetBusinessId == id).ToList();
        }

        public FeedUpdate FindUpdateById(int updateId) => FindByCondition(u => u.Id == updateId).FirstOrDefault();
        public FeedUpdate FindUpdateByUserId(string identityUserId) => FindByCondition(u => u.PetBusiness.IdentityUserId == identityUserId).FirstOrDefault();

        public ICollection<FeedUpdate> GetAllUpdates()
        {
            return FindAll().ToList();
        }
    }
}
