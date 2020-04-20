using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using petOwnerOneStopShop.Models;

namespace petOwnerOneStopShop.Contracts
{
    public interface IInviteRepository : IRepositoryBase<Invite>
    {
        void CreateInvite(Invite invite);
    }
}
