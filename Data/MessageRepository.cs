using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PawentsOneStopShop.Contracts;
using PawentsOneStopShop.Models;

namespace PawentsOneStopShop.Data
{
    public class MessageRepository : RepositoryBase<Message>, IMessageRepository
    {
        public MessageRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {

        }
        public void CreateMessage(DateTime timeCreated, string userTo, string userFrom, string content)
        {
            Message message = new Message();
            message.TimeStamp = timeCreated;
            message.UserToId = userTo;
            message.UserFromID = userFrom;
            message.MessageContent = content;
            Create(message);
        }
        public ICollection<Message> GetMessageToUserAndFromUser(string userTo, string userFrom)
        {
            return FindByCondition(m => m.UserToId == userTo && m.UserFromID == userFrom).ToList();
        }
    }
}
