using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PawentsOneStopShop.Models;

namespace PawentsOneStopShop.Contracts
{
    public interface IFollowRepository : IRepositoryBase<Follow>
    {
        void CreateFollow(Follow follow);
        //void FindFollowById(int followId);
        Follow FindFollowByPetBusinessId(int petBusinessId);
        Follow FindFollowByPetOwnerId(int petBusinessId);
        void Unfollow(int? id, int petBusinessId, int petOwnerId);
        void Follow(int? id, int petBusinessId, int petOwnerId);
        ICollection<Follow> GetAllFollowsEqualTrueByPetOwnerIncludeAll(int petOwnerId);
        Follow GetFollowByPetOwnerAndPetBusiness(int petBusinessId, int petOwnerId);
    }
}
