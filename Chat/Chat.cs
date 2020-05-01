using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using PawentsOneStopShop.Contracts;

namespace PawentsOneStopShop.Chat
{
    public class Chat : Hub
    {
        private readonly IRepositoryWrapper _repo;
        public Chat(IRepositoryWrapper repo)
        {
            _repo = repo;
        }
        public async Task SendMessage(string timeStamp, string userTo, string userFrom, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", userFrom, userTo, message, timeStamp);
        }
        public void SaveMessage(DateTime timeStamp, string userFrom, string userTo, string message)
        {
            _repo.Message.CreateMessage(timeStamp, userTo, userFrom, message);
            _repo.Save();
        }
        public ICollection<string> SavedMessages(string userTo, string userFrom)
        {
            List<string> messages = _repo.Message.GetMessageToUserAndFromUser(userTo, userFrom).Select(m => m.TimeStamp + " " + m.UserFromID + ": " + m.MessageContent).ToList();
            return messages;
        }

    }
}
