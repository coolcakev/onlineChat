using Microsoft.AspNetCore.Mvc;
using onlineChat.Entity;
using onlineChat.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlineChat.Controllers
{
    public class MessageController : Controller
    {        

        [HttpPost]
        public IActionResult ShowMessage([FromBody] Message message)
        {       
            
            return PartialView("_Message", message);
        }
    }
}
