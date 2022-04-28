using onlineChat.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlineChat.Models.HomeModels
{
    public class ChatsPartialHomeModel
    {
        public IEnumerable<Chat> Chats { get; set; }
        public string GroupChatId { get; set; }
    }
}
