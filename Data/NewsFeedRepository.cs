using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using petOwnerOneStopShop.Contracts;
using petOwnerOneStopShop.Models;

namespace petOwnerOneStopShop.Data
{
    public class NewsFeedRepository : RepositoryBase<NewsFeed>, INewsFeedRepository
    {
        public NewsFeedRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {

        }

        public NewsFeed GetNewsFeedByPetBusiness(int petBusinessId) => FindByCondition(n => n.PetBusinessId == petBusinessId).FirstOrDefault();
    }
}
