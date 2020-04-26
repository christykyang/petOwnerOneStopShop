using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PawentsOneStopShop.Contracts;
using PawentsOneStopShop.Models;

namespace PawentsOneStopShop.Data
{
    public class NewsFeedRepository : RepositoryBase<NewsFeed>, INewsFeedRepository
    {
        public NewsFeedRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {

        }

        //public NewsFeed GetNewsFeedByPetBusiness(int petBusinessId) => FindByCondition(n => n.PetBusinessId == petBusinessId).FirstOrDefault();
        //public NewsFeed GetNewsFeedByPetOwner(int petOwnerId) => FindByCondition(n => n.PetOwnerId == petOwnerId).FirstOrDefault();
        public NewsFeed GetNewsFeedByIdentityUserId(string identityUserId) => FindByCondition(n => n.IdentityUserId == identityUserId).FirstOrDefault();
        public void CreateNewsFeedByUserId(string identityUserId)
        {
            NewsFeed newsFeed = new NewsFeed();
            newsFeed.IdentityUserId = identityUserId;
            //newsFeed.PetBusinessId = null;
            //newsFeed.PetOwnerId = null;
            //newsFeed.Updates = new List<FeedUpdate>();
            Create(newsFeed);
        }
        public void CreateNewsFeed(int userId, string identityUserId)
        {
            NewsFeed newsFeed = new NewsFeed();
            newsFeed.IdentityUserId = identityUserId;
            newsFeed.UserId = userId;
            Create(newsFeed);
        }
    }
}
