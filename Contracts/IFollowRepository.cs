using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using petOwnerOneStopShop.Models;

namespace petOwnerOneStopShop.Contracts
{
    public interface IFollowRepository : IRepositoryBase<Follow>
    {
        void CreateFollow(Follow follow);
        //void FindFollowById(int followId);
        Follow FindFollowByPetBusinessId(int petBusinessId);
        Follow FindFollowByPetOwnerId(int petBusinessId);
    }
}
