using onlineChat.Base;
using onlineChat.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlineChat.Service
{
    public interface IMessageService
    {
        Message ShowMessage(int messageId);
    }
    public class MessageService: IMessageService
    {
        private readonly ApplicationContext _repository;

        public MessageService(ApplicationContext applicationContext)
        {
            _repository = applicationContext;
        }

        public Message ShowMessage(int messageId)
        {
            return _repository.Messages.SingleOrDefault(message=> message.Id==messageId);
        }
    }
}
