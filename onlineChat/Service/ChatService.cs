
using Microsoft.EntityFrameworkCore;
using onlineChat.Base;
using onlineChat.Commands;
using onlineChat.Entity;
using onlineChat.Models.ChatsModels;
using onlineChat.Models.ChatsModels.GetMessagesChatModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlineChat.Service
{
    public interface IChatService
    {
        Task GetMessages(RequestGetMessagesChatModel model, ResponceGetMessagesChatModel responceModel);
        Task<bool> JoinUser(JoinUserChatModel model);
        Task<Chat> Create(CreateChatModel model);
    }
    public class ChatService : IChatService
    {
        private readonly ApplicationContext _repository;
        private readonly IGetChatDependsUserCommand _getChatDependsUserCommand;

        public ChatService(ApplicationContext applicationContext, IGetChatDependsUserCommand getChatDependsUserCommand)
        {
            _repository = applicationContext;
            _getChatDependsUserCommand = getChatDependsUserCommand;
        }

        public async Task<Chat> Create(CreateChatModel model)
        {
            var chatType = (TypeChat)Enum.Parse(typeof(TypeChat), model.Type);
            var chat = new Chat()
            {
                Title = model.Title,
                TypeChat = chatType
            };
            await _repository.AddAsync(chat);
            await _repository.SaveChangesAsync();
            return chat;
        }

        public async Task GetMessages(RequestGetMessagesChatModel model, ResponceGetMessagesChatModel responceModel)
        {
            var chat = _repository.Chats.Include(x => x.Messages).Include(x => x.Users).SingleOrDefault(chat => chat.Id == model.ChatId);
            if (chat == null)
                return;

            responceModel.Messages = chat.Messages.OrderByDescending(x => x.CreationDate);
            responceModel.Chat = chat;      

            var user = chat.Users.SingleOrDefault(user => user.Name == model.UserName);
            responceModel.IsJoinedToChat = user != null;
            if (TypeChat.Chat == chat.TypeChat)
            {
                var updatedChat = await _getChatDependsUserCommand.Execute(chat, user);
                responceModel.Chat = updatedChat;
            }

        }

        public async Task<bool> JoinUser(JoinUserChatModel model)
        {
            var user = await _repository.Users.Include(x => x.Chats).SingleOrDefaultAsync(user => user.Name == model.UserName);
            if (user == null)
                return false;
            user.ConnectionId = model.UserConnectionId;

            var chat = await _repository.Chats.SingleOrDefaultAsync(chat => chat.Id == model.ChatId);
            if (chat == null)
                return false;

            user.Chats.Add(chat);
            _repository.Update(user);
            await _repository.SaveChangesAsync();
            return true;


        }
    }
}
