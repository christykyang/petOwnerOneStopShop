using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using petOwnerOneStopShop.Models;

namespace petOwnerOneStopShop.Contracts
{
    public interface IFeedUpdateRepository : IRepositoryBase<FeedUpdate>
    {
        Task<ICollection<FeedUpdate>> FindUpdatesByPetBusinessIncludeAll(string userId);
        Task<ICollection<FeedUpdate>> FindUpdatesByPetBusinessIdIncludeAll(int id);
        FeedUpdate FindUpdateById(int updateId);
        FeedUpdate FindUpdateByUserId(string identityUserId) => FindByCondition(u => u.NewsFeed.IdentityUserId == identityUserId).FirstOrDefault();
    }
}
