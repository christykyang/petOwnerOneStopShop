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
        FeedUpdate FindUpdateById(int updateId);
    }
}
