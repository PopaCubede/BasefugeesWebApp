using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BasefugeesWebApp.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BasefugeesWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace BasefugeesWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOptions<AppSettingsModel> _appSettings;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IOptions<AppSettingsModel> app)
        {
            _logger = logger;
            _appSettings = app;
            WebConfig.ApiUrl = Constants.ApiUrl;
            WebConfig.AlgoliaAppID = Constants.AlgoliaAppID;
            WebConfig.AlgoliaAPIKey = Constants.AlgoliaAPIKey;
        }

        public async Task<IActionResult> Index()
        {
            //var data = await ApiClientFactory.Instance.GetUsers();
            return View();
        }

        [Authorize]
        public IActionResult MyClaims()
        {
            return View();
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
