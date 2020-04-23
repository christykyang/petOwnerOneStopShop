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
            return await FindByCondition(f => f.NewsFeed.IdentityUserId == userId).ToListAsync();
        }

        public FeedUpdate FindUpdateById(int updateId) => FindByCondition(u => u.Id == updateId).FirstOrDefault();
    }
}
