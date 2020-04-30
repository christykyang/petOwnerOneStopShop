using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PawentsOneStopShop.Contracts;
using PawentsOneStopShop.Models;

namespace PawentsOneStopShop.Data
{
    public class FollowRepository : RepositoryBase<Follow>, IFollowRepository
    {
        public FollowRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {

        }
        public void CreateFollow(Follow follow) => Create(follow);
        public Follow GetFollowById(int followId)
        {
            return FindByCondition(f => f.Id == followId).FirstOrDefault();
        }
        public Follow GetFollowByPetOwnerAndPetBusiness(int petBusinessId, int petOwnerId)
        {
            return FindByCondition(f => f.PetBusinessId == petBusinessId && f.PetOwnerId == petOwnerId).FirstOrDefault();
        }
        public ICollection<Follow> GetAllFollowsEqualTrueByPetOwnerIncludeAll(int petOwnerId)
        {
            return FindAll().Include(f => f.PetBusiness).Where(o => o.PetOwnerId == petOwnerId && o.IsFollowing == true).ToList();
        }
        public Follow FindFollowByPetBusinessId(int petBusinessId)
        { return FindByCondition(b => b.PetBusinessId == petBusinessId).FirstOrDefault(); }
        public Follow FindFollowByPetOwnerId(int petOwnerId)
        { return FindByCondition(o => o.PetOwnerId == petOwnerId).FirstOrDefault(); }

        //public int GetFollowIdByPetOwnerAndPetBusiness(int petBusinessId, int petOwnerId)
        //{
        //    Follow follow = new Follow();
        //    follow.Id = ApplicationDbContext.Follow.Where(f => f.PetOwnerId == petOwnerId && f.PetBusinessId == petBusinessId); ;
        //}

        public void Unfollow(int? id, int petBusinessId, int petOwnerId)
        {
            Follow following = ApplicationDbContext.Follow.Where(f => f.Id == id).FirstOrDefault();
            following.PetBusinessId = petBusinessId;
            following.PetOwnerId = petOwnerId;
            following.IsFollowing = false;
            Update(following);
        }
        public void Follow(int? id, int petBusinessId, int petOwnerId)
        {
            Follow following = ApplicationDbContext.Follow.Where(f => f.Id == id).FirstOrDefault();
            following.PetBusinessId = petBusinessId;
            following.PetOwnerId = petOwnerId;
            following.IsFollowing = true;
            Update(following);
        }
    }
}
