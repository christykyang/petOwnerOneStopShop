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

        public NewsFeed GetNewsFeedByPetOwner(int petOwnerId) => FindByCondition(n => n.PetOwnerId == petOwnerId).FirstOrDefault();
        //public void CreateNewsFeed(int petOwnerId, int followId, int update)
        //{
        //    NewsFeed newsFeed = new NewsFeed();
        //    newsFeed.PetOwnerId = petOwnerId;
        //    Create(newsFeed);
        //}
    }
}
