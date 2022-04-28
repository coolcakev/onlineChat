using Microsoft.AspNetCore.SignalR;
using onlineChat.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlineChat.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendChat(Chat chat, string placeForChatId)
        {
            await Clients.All.SendAsync("SendChat", chat, placeForChatId);
        }
        public async Task SendMessage(string chatId, Message message, User author)
        {
            await Clients.Group(chatId).SendAsync("SendMessage", message, author);
        }
        public async Task JoinManyGroup(List<string> groupsId)
        {
            foreach (var groupId in groupsId)
                await Groups.AddToGroupAsync(Context.ConnectionId, groupId);

        }
        public async Task JoinGroup(string groupId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupId);
        }
        public async Task JoinGroupMyFriend(string groupId,string connectionId)
        {
            await Groups.AddToGroupAsync(connectionId, groupId);
        }
        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("GetConnetctedId", Context.ConnectionId);
            await base.OnConnectedAsync();
        }
    }
}
