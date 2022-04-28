using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using onlineChat.Entity;
using onlineChat.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlineChat.Base
{
    public class BaseController : Controller
    {
        private readonly ISession _session;
        private string sessionKey = "UserName";
        public BaseController(IHttpContextAccessor contextAccessor)
        {
            _session = contextAccessor.HttpContext.Session;
        }

        protected virtual User GetUser()
        {          
            return SessionHelper.GetItemFromSession<User>(sessionKey, _session);
        }
        protected virtual void SetUser(User user)
        {          
             SessionHelper.SetItemInSession(user,sessionKey, _session);
        }
    }
}
