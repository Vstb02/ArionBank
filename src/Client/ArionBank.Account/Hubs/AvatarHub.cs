using ArionBank.Account.Models;
using Microsoft.AspNetCore.SignalR;

namespace ArionBank.Account.Hubs
{
    public class AvatarHub : Hub
    {
        public async Task SendAvatar(UserModel user)
        {
            await Clients.All.SendAsync("ReceiveMessage", user);
        }
    }
}
