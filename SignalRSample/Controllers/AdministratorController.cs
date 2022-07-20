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
    public class AdministratorController : Controller
    {
        private readonly IHubContext<NotificationHub> _notificationHubContext;

        public AdministratorController(IHubContext<NotificationHub> notificationHubContext)
        {
            _notificationHubContext = notificationHubContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(PromotionViewModel promotionModel)
        {
            await _notificationHubContext.Clients.All.SendAsync("notificationReceived", promotionModel.Title, promotionModel.Title, promotionModel.Title, promotionModel.Description);
            ModelState.Clear();
            ViewData["FormSubmitSuccess"] = true;
            return View();
        }
    }
}
