using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PawentsOneStopShop.Models;

namespace PawentsOneStopShop.Contracts
{
    public interface IMessageRepository : IRepositoryBase<Message>
    {
        void CreateMessage(DateTime timeCreated, string userTo, string userFrom, string content);
        ICollection<Message> GetMessageToUserAndFromUser(string userTo, string userFrom);
    }
}
