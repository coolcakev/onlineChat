using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlineChat.Entity
{
    public class Message
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public User User  { get; set; }
        public int UserId { get; set; }
        public Chat Chat { get; set; }
        public int ChatId { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
