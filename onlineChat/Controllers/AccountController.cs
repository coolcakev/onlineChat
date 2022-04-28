using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using onlineChat.Base;
using onlineChat.Helpers;
using onlineChat.Models.AccountModels;
using onlineChat.Models.AccountModels.SendMessageAccountModel;
using onlineChat.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onlineChat.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService, IHttpContextAccessor contextAccessor) : base(contextAccessor)
        {
            _accountService = accountService;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login([FromBody] LoginAccountModel model)
        {
            if (string.IsNullOrWhiteSpace(model.UserName))
                return NotFound();

            _accountService.Login(model);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateUserConnectionId([FromBody] UpdateUserConnectionIdAccountModel model)
        {
            if (string.IsNullOrWhiteSpace(model.ConnectionId))
                return NotFound();

            var user = GetUser();
            model.UserName = user.Name;
            user = await _accountService.UpdateUserConnectionId(model);
            if (user == null)
                return NotFound();

            SetUser(user);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage([FromBody] RequestSendMessageAccountModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Message))
                return NotFound();

            var user = GetUser();
            model.UserId = user.Id;
            var responceModel = new ResponceSendMessageAccountModel();
            var isSendMessageValid = await _accountService.SendMessage(model, responceModel);
            if (!isSendMessageValid)
                return NotFound();


            var stringResponce = JsonConvert.SerializeObject(responceModel, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Ok(stringResponce);
        }
    }
}
