using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using onlineChat.Entity;
using onlineChat.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace onlineChat.Attributes
{
    public class AccesssAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = SessionHelper.GetItemFromSession<User>("UserName", context.HttpContext.Session);
            if (user == null)
            {
                context.Result = new RedirectResult("/Account/Login");
                return;
            }
            
        }
    }
}
