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
        public async Task SendMessage(string userFrom, string userTo, string message, string timeStamp)
        {
            await Clients.All.SendAsync("ReceiveMessage", userFrom, userTo, message, timeStamp);
        }


    }
}
