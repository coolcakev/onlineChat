using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlineChat.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ConnectionId { get; set; }
        public List<Message> Messages { get; set; }
        public List<Chat> Chats { get; set; }

    }
}
