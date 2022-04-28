using Microsoft.EntityFrameworkCore;
using onlineChat.Base;
using onlineChat.Commands;
using onlineChat.Entity;
using onlineChat.Models.HomeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlineChat.Service
{
    public interface IHomeService
    {
        Task FillIndexModel(IndexHomeModel model);
        IEnumerable<Chat> Allchats();
    }
    public class HomeService: IHomeService
    {
        private readonly ApplicationContext _repository;
        private readonly IGetChatDependsUserCommand _getChatDependsUserCommand;

        public HomeService(ApplicationContext applicationContext, IGetChatDependsUserCommand getChatDependsUserCommand)
        {
            _repository = applicationContext;
            _getChatDependsUserCommand = getChatDependsUserCommand;
        }

        public IEnumerable<Chat> Allchats()
        {
            return _repository.Chats;
        }

        public async Task FillIndexModel(IndexHomeModel model)
        {
            model.Chats = _repository.Chats.Where(chat=>chat.TypeChat!=TypeChat.Chat);
            var user = _repository.Users.Include(x => x.Chats).ThenInclude(x=>x.Users).SingleOrDefault(user => user.Name == model.userName);
            if (user == null)
            {
                model.MyChats = new List<Chat>();
                model.Friends = new List<Chat>();
                return;
            }
            var typeChat = TypeChat.Group;
            model.MyChats = user.Chats.Where(chat => chat.TypeChat == typeChat).ToList();

             typeChat = TypeChat.Chat;
            var chatsFromDb = user.Chats.Where(chat => chat.TypeChat == typeChat);
            var chats = new List<Chat>();
            foreach (var chatFromDb in chatsFromDb)
            {
                var chat = await _getChatDependsUserCommand.Execute(chatFromDb,user);
                chats.Add(chat);
            }
            model.Friends = chats;


        }   
    }
}
