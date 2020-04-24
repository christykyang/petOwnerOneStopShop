using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using petOwnerOneStopShop.Contracts;
using petOwnerOneStopShop.Models;

namespace petOwnerOneStopShop.Data
{
    public class FeedUpdateRepository : RepositoryBase<FeedUpdate>, IFeedUpdateRepository
    {
        public FeedUpdateRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {

        }
        public async Task<ICollection<FeedUpdate>> FindUpdatesByPetBusinessIncludeAll(string userId)
        {
            return await FindAll().Where(f => f.NewsFeed.IdentityUserId == userId).ToListAsync();
        }
        public async Task<ICollection<FeedUpdate>> FindUpdatesByPetBusinessIdIncludeAllAsync(int id)
        {
            return await FindAll().Where(f => f.NewsFeed.PetBusinessId == id).ToListAsync();
        }

        public ICollection<FeedUpdate> FindUpdatesByPetBusinessIdIncludeAll(int id)
        {
            return FindAll().Where(f => f.NewsFeed.PetBusinessId == id).ToList();
        }

        public ICollection<FeedUpdate> FindUpdatesByNewsFeedId(int id)
        {
            return FindAll().Where(f => f.NewsFeedId == id).ToList();
        }

        public FeedUpdate FindUpdateById(int updateId) => FindByCondition(u => u.Id == updateId).FirstOrDefault();
        public FeedUpdate FindUpdateByUserId(string identityUserId) => FindByCondition(u => u.NewsFeed.IdentityUserId == identityUserId).FirstOrDefault();
    }
}
