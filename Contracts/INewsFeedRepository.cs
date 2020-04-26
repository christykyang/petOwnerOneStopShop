using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PawentsOneStopShop.Models;

namespace PawentsOneStopShop.Contracts
{
    public interface INewsFeedRepository : IRepositoryBase<NewsFeed>
    {
        NewsFeed GetNewsFeedByPetOwner(int petOwnerId);
        //void CreateNewsFeed(int petOwnerId);
    }
}
