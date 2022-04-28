using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlineChat.Models.ChatsModels.GetMessagesChatModel
{
    public class RequestGetMessagesChatModel
    {
        public int ChatId { get; set; }
        public string UserName { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
