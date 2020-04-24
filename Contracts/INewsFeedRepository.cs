using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using petOwnerOneStopShop.Models;

namespace petOwnerOneStopShop.Contracts
{
    public interface INewsFeedRepository : IRepositoryBase<NewsFeed>
    {
        NewsFeed GetNewsFeedByPetBusiness(int petBusinessId);
        NewsFeed GetNewsFeedByPetOwner(int petOwnerId);
    }
}
