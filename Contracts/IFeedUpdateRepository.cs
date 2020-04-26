using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PawentsOneStopShop.Models;

namespace PawentsOneStopShop.Contracts
{
    public interface IFeedUpdateRepository : IRepositoryBase<FeedUpdate>
    {
        Task<ICollection<FeedUpdate>> FindUpdatesByPetBusinessIncludeAll(string userId);
        Task<ICollection<FeedUpdate>> FindUpdatesByPetBusinessIdIncludeAllAsync(int id);
        ICollection<FeedUpdate> FindUpdatesByPetBusinessIdIncludeAll(int id);
        FeedUpdate FindUpdateById(int updateId);
        ICollection<FeedUpdate> FindUpdatesByNewsFeedId(int id);
        ICollection<FeedUpdate> GetAllUpdates();
    }
}
