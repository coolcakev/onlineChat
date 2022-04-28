using Microsoft.AspNetCore.Http;
using onlineChat.Base;
using onlineChat.Entity;
using onlineChat.Helpers;
using onlineChat.Models.AccountModels;
using onlineChat.Models.AccountModels.SendMessageAccountModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlineChat.Service
{
    public interface IAccountService
    {
        void Login(LoginAccountModel model);
        Task<bool> SendMessage(RequestSendMessageAccountModel model, ResponceSendMessageAccountModel responceModel);
        Task<User> UpdateUserConnectionId(UpdateUserConnectionIdAccountModel model);
    }
    public class AccountService : IAccountService
    {
        private readonly ApplicationContext _repository;
        private readonly ISession _session;

        public AccountService(ApplicationContext applicationContext, IHttpContextAccessor contextAccessor)
        {
            _repository = applicationContext;
            _session = contextAccessor.HttpContext.Session;
        }

        public void Login(LoginAccountModel model)
        {
            var user = _repository.Users.SingleOrDefault(user => user.Name == model.UserName);
            if (user == null)
            {
                user = new User()
                {
                    Name = model.UserName
                };
                _repository.Add(user);
                _repository.SaveChanges();
            }

            SessionHelper.SetItemInSession(user, "UserName", _session);
        }

        public async Task<bool> SendMessage(RequestSendMessageAccountModel model, ResponceSendMessageAccountModel responceModel)
        {

            var user = _repository.Users.SingleOrDefault(user => user.Id == model.UserId);
            if (user == null)
                return false;

            var chat = _repository.Chats.SingleOrDefault(chat => chat.Id == model.ChatId);
            if (chat == null)
                return false;

            var message = new Message()
            {
                Content = model.Message,
                CreationDate = DateTime.Now,
                Chat = chat,
                User = user,
            };
            await _repository.AddAsync(message);
            await _repository.SaveChangesAsync();

            responceModel.ChatId = chat.Id;
            responceModel.Message = message;
            responceModel.User = user;

            return true;
        }

        public async Task<User> UpdateUserConnectionId(UpdateUserConnectionIdAccountModel model)
        {
            var user = _repository.Users.SingleOrDefault(user => user.Name == model.UserName);
            if (user == null)
                return null;
            user.ConnectionId = model.ConnectionId;
            _repository.Update(user);
            await _repository.SaveChangesAsync();

            return user;
        }

    }
}
