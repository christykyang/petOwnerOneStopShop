using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using petOwnerOneStopShop.Contracts;
using petOwnerOneStopShop.Models;

namespace petOwnerOneStopShop.Data
{
    public class MessageRepository : RepositoryBase<Message>, IMessageRepository
    {
        public MessageRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {

        }
    }
}
