using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace onlineChat.Helpers
{
    public static class SessionHelper
    {
        public static T GetItemFromSession<T>(string sessionKey, ISession session)
        {
            var isItemFromSession = session.Keys.Contains(sessionKey);
            if (isItemFromSession)
            {
                var jsonItem = session.GetString(sessionKey);
                var parseItemFromSession = JsonSerializer.Deserialize<T>(jsonItem);
                return parseItemFromSession;
            }
            return default(T);
        }
        public static void SetItemInSession<T>(T item,string sessionKey, ISession session)
        {
            session.SetString(sessionKey, JsonSerializer.Serialize<T>(item));
        }
    }
}
