using onlineChat.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlineChat.Models.AccountModels
{
    public class RequestSendMessageAccountModel
    {
        public int ChatId { get; set; }
        public string Message { get; set; }
        public int UserId { get; set; }
    }
}
