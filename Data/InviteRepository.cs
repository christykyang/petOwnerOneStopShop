using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PawentsOneStopShop.Contracts;
using PawentsOneStopShop.Models;

namespace PawentsOneStopShop.Data
{
    public class InviteRepository : RepositoryBase<ObjectInvite>, IInviteRepository
    {
        public InviteRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {

        }
        public void CreateInvite(ObjectInvite invite) => Create(invite);
    }
}
