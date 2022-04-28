using onlineChat.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlineChat.Models.ChatsModels
{
    public class ResponceGetMessagesChatModel
    {     
        public IEnumerable<Message> Messages { get; set; }
        public Chat Chat { get; set; }
        public bool IsJoinedToChat { get; set; }
        public int  UserId { get; set; }
    }
}
