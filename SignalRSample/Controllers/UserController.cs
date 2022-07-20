using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRSample.Hubs;
using SignalRSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRSample.Controllers
{
    public class UserController : Controller
    {
        private readonly IHubContext<NotificationHub> _notificationHubContext;

        public UserController(IHubContext<NotificationHub> notificationHubContext)
        {
            _notificationHubContext = notificationHubContext;
        }

        public IActionResult Index()
        {
            return RedirectToAction(nameof(Account));
        }

        public IActionResult Account(int? id)
        {
            if (id is null)
            {
                return RedirectToAction(nameof(Account), new { id = 1 });
            }

            ViewData["UserId"] = id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Promotion promotionModel)
        {
            await _notificationHubContext.Clients.All.SendAsync("notificationReceived", promotionModel.Guid, promotionModel.Type, promotionModel.Title, promotionModel.Description);
            return View();
        }
    }
}
