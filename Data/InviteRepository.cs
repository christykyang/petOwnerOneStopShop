using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PawentsOneStopShop.Contracts;
using PawentsOneStopShop.Models;

namespace PawentsOneStopShop.Data
{
    public class InviteRepository : RepositoryBase<ObjectInvite>, IObjectInviteRepository
    {
        public InviteRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {

        }
        public void CreateInvite(ObjectInvite invite) => Create(invite);
        public ICollection<ObjectInvite> GetInvitesSentToOwner(int ownerId)
        {
            return FindAll().Where(i => i.OwnerInvitedId == ownerId).ToList();
        }
        
    }
}
