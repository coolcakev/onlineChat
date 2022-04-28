using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlineChat.Models.ChatsModels
{
    public class JoinUserChatModel
    {
        public int  ChatId { get; set; }
        public string  UserName { get; set; }
        public string UserConnectionId { get; set; }
    }
}
