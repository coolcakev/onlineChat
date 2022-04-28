using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using onlineChat.Base;
using onlineChat.Models.ChatsModels;
using onlineChat.Models.ChatsModels.GetMessagesChatModel;
using onlineChat.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlineChat.Controllers
{
    public class ChatController : BaseController
    {
        private readonly IChatService _chatService;

        public ChatController(IChatService chatService, IHttpContextAccessor contextAccessor) : base(contextAccessor)
        {
            _chatService = chatService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMessages(RequestGetMessagesChatModel model)
        {
            var responceModel = new ResponceGetMessagesChatModel();
            var user = GetUser();
            model.UserName = user.Name;
            await _chatService.GetMessages(model, responceModel);
            responceModel.UserId = user.Id;
            return PartialView("_Messages", responceModel);
        }
        [HttpPost]
        public async Task<IActionResult> JoinUser([FromBody] JoinUserChatModel model)
        {
            if (string.IsNullOrWhiteSpace(model.UserName) || string.IsNullOrWhiteSpace(model.UserConnectionId))
            {
                var user = GetUser();
                model.UserName = user.Name;
                model.UserConnectionId = user.ConnectionId;
            }
            var isValidJoinUser = await _chatService.JoinUser(model);
            if (!isValidJoinUser)
                return NotFound();

            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateChatModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Title))
                return NotFound();

            var chat = await _chatService.Create(model);

            return Ok(chat);
        }
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] UpdateChatModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Title))
                return NotFound();

            var chat = await _chatService.Create(model);

            return Ok(chat);
        }
    }
}
