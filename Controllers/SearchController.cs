using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Algolia.Search.Clients;
using BasefugeesWebApp.DAL.AlgoliaModels;
using BasefugeesWebApp.Helpers;
using BasefugeesWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BasefugeesWebApp.Controllers
{
    public class SearchController : Controller
    {
        private readonly IOptions<AppSettingsModel> _appSettings;
        private readonly ILogger<HomeController> _logger;

        private readonly ISearchClient _searchClient;

        public SearchController(ILogger<HomeController> logger, IOptions<AppSettingsModel> app
            //, ISearchClient searchClient
        )
        {
            _logger = logger;
            _appSettings = app;
            WebConfig.AlgoliaAPIKey = _appSettings.Value.AlgoliaAPIKey;
            WebConfig.AlgoliaAppID = _appSettings.Value.AlgoliaAppID;
            _searchClient = new SearchClient(WebConfig.AlgoliaAPIKey, WebConfig.AlgoliaAppID);
        }

        // GET: Search
        public async Task<ActionResult> Index(string searchEntered)
        {
            if (!string.IsNullOrEmpty(searchEntered))
            {
                var projects = new List<AlgoliaProjectModel>();

                //// Asynchronous
                //var projectsIndex = _searchClient.InitIndex("projects-test");
                //var result = await projectsIndex.SearchAsync<AlgoliaProjectModel>(new Query(searchEntered)
                //{
                //    AttributesToRetrieve = new List<string> { "name", "description" },
                //    HitsPerPage = 50
                //});
                //IEnumerable<AlgoliaProjectModel> projectsAlgolia = result.Hits;

                return View(projects);
            }

            return View();
        }
    }
}