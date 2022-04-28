using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using onlineChat.Attributes;
using onlineChat.Base;
using onlineChat.Entity;
using onlineChat.Helpers;
using onlineChat.Models;
using onlineChat.Models.HomeModels;
using onlineChat.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace onlineChat.Controllers
{
    [TypeFilter(typeof(AccesssAttribute))]
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeService _homeService;

        public HomeController(ILogger<HomeController> logger, IHomeService homeService, IHttpContextAccessor contextAccessor) : base(contextAccessor)
        {
            _logger = logger;
            _homeService = homeService;

        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = new IndexHomeModel();
            var user = GetUser();
            ViewBag.UserName = user.Name;
            model.userName = user.Name;
            await _homeService.FillIndexModel(model);
            return View(model);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
