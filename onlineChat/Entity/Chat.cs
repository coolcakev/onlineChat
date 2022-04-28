using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlineChat.Entity
{
    public class Chat
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<User> Users { get; set; }
        public IEnumerable<Message> Messages { get; set; }
        public TypeChat TypeChat { get; set; }
    }
    public enum TypeChat
    {
        Group,
        Chat
    }
}
