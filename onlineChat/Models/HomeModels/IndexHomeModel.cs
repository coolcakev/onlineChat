using onlineChat.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlineChat.Models.HomeModels
{
    public class IndexHomeModel
    {
        public IEnumerable<Chat> Chats { get; set; }  
        public IEnumerable<Chat> MyChats { get; set; }  
        public IEnumerable<Chat> Friends { get; set; }
        public string userName { get; set; }
    }
}
