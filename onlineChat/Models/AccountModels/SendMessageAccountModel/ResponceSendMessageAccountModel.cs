using onlineChat.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlineChat.Models.AccountModels.SendMessageAccountModel
{
    public class ResponceSendMessageAccountModel
    {
        public int ChatId { get; set; }
        public Message Message { get; set; }
        public User User { get; set; }
    }
}
