using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PawentsOneStopShop.Models;

namespace PawentsOneStopShop.Contracts
{
    public interface IInviteRepository : IRepositoryBase<ObjectInvite>
    {
        void CreateInvite(ObjectInvite objectInvite);
        ICollection<ObjectInvite> GetInvitesSentToOwner(int ownerId);
    }
}
