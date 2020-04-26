using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PawentsOneStopShop.Models;

namespace PawentsOneStopShop.Contracts
{
    public interface INewsFeedRepository : IRepositoryBase<NewsFeed>
    {
        //NewsFeed GetNewsFeedByPetBusiness(int petBusinessId);
        //NewsFeed GetNewsFeedByPetOwner(int petOwnerId);
        NewsFeed GetNewsFeedByIdentityUserId(string identityUserId);
        void CreateNewsFeedByUserId(string identityUserId);
        void CreateNewsFeed(int userId, string identityUserId);
    }
}
