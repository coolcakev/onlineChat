using onlineChat.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlineChat.Commands
{
    public interface IGetChatDependsUserCommand
    {
        Task<Chat> Execute(Chat previousChat, User user);
    }
    public class GetChatDependsUserCommand : IGetChatDependsUserCommand
    {
        public async Task<Chat> Execute(Chat previousChat,User user)
        {
            if (user == null)
                return previousChat;

            var chat = new Chat()
            {
                Id = previousChat.Id,
                Title = previousChat.Title,
                Messages = previousChat.Messages,
                TypeChat = previousChat.TypeChat,
                Users = previousChat.Users,
            };
            if (chat.Users[0].Id == user.Id)
            {
                chat.Title = chat.Users[1].Name;
                return chat;
            }
            chat.Title = chat.Users[0].Name;
            return chat;

        }
    }
}
