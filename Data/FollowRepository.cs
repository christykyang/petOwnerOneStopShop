using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using petOwnerOneStopShop.Contracts;
using petOwnerOneStopShop.Models;

namespace petOwnerOneStopShop.Data
{
    public class FollowRepository : RepositoryBase<Follow>, IFollowRepository
    {
        public FollowRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {

        }
        public void CreateFollow(Follow follow) => Create(follow);
    }
}
