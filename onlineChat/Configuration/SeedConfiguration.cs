using onlineChat.Base;
using onlineChat.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlineChat.Configuration
{
    public static class SeedConfiguration
    {
        public async static Task SetDefaultChat(ApplicationContext repository)
        {
            var chats = repository.Chats;
            if (chats.Count() != 0)
                return;

            var chat = new Chat()
            {
                Title = "General chat"
            };
            repository.Add(chat);
           await repository.SaveChangesAsync();
        }
    }
}
