using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Algolia.Search.Clients;
using Algolia.Search.Models.Search;
using BasefugeesWebApp.DAL.AlgoliaModels;
using BasefugeesWebApp.DAL.ApiClients;
using BasefugeesWebApp.DAL.DTO;
using BasefugeesWebApp.Helpers;
using BasefugeesWebApp.Models;
using BasefugeesWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BasefugeesWebApp.Controllers
{
    public class AlgoliaController : Controller
    {
        private readonly IOptions<AppSettingsModel> _appSettings;
        private readonly ILogger<AlgoliaController> _logger;

        private readonly ISearchClient _searchClient;

        public AlgoliaController(ILogger<AlgoliaController> logger, IOptions<AppSettingsModel> app
            , ISearchClient searchClient
        )
        {
            _logger = logger;
            _appSettings = app;
            WebConfig.AlgoliaAPIKey = Constants.AlgoliaAPIKey;
            WebConfig.AlgoliaAppID = Constants.AlgoliaAppID;
            _searchClient = searchClient;
        }

        // GET: Search
        public async Task<ActionResult> Index([FromForm] SearchSettingViewModel searchSettings)
        {
            if (!string.IsNullOrEmpty(searchSettings.SearchEntered))
            {
                var projects = new List<ProjectModel>();
                var users = new List<UserModel>();

                if (searchSettings.TypeSearched == "IsProject")
                {
                    //projects = await ApiClientFactory.Instance.GetProjects();
                    //var projectsResult = projects.FindAll(p => p.Name.Contains(searchSettings.SearchEntered));
                    //projectsResult.AddRange(projects.FindAll(p => p.Description.Contains(searchSettings.SearchEntered)));
                    //projectsResult.AddRange(projects.FindAll(p => p.Location.Contains(searchSettings.SearchEntered)));
                    //projectsResult.AddRange(projects.FindAll(p => p.ShortDescription.Contains(searchSettings.SearchEntered)));

                    // Asynchronous
                    var projectsIndex = _searchClient.InitIndex("projects-test");
                    var result = await projectsIndex.SearchAsync<AlgoliaProjectModel>(new Query(searchSettings.SearchEntered)
                    {
                        //AttributesToRetrieve = new List<string> { "name", "description" },
                        HitsPerPage = 50
                    });
                    IEnumerable<AlgoliaProjectModel> projectsAlgolia = result.Hits;

                    return View($"Projects", projectsAlgolia);
                }

                if (searchSettings.TypeSearched == "IsUser")
                {
                    //users = await ApiClientFactory.Instance.GetUsers();
                    //var usersResult = users.FindAll(u => u.Name.Contains(searchSettings.SearchEntered));
                    //usersResult.AddRange(users.FindAll(u => u.Email.Contains(searchSettings.SearchEntered)));
                    //usersResult.AddRange(users.FindAll(u => u.Bio.Contains(searchSettings.SearchEntered)));

                    // Asynchronous
                    var usersIndex = _searchClient.InitIndex("users-test");
                    var result = await usersIndex.SearchAsync<AlgoliaUserModel>(new Query(searchSettings.SearchEntered)
                    {
                        //AttributesToRetrieve = new List<string> { "name", "description" },
                        HitsPerPage = 50
                    });
                    IEnumerable<AlgoliaUserModel> usersAlgolia = result.Hits;

                    return View($"Users", usersAlgolia);
                }
            }

            return View();
        }
    }
}