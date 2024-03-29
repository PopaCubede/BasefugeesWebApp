﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Algolia.Search.Clients;
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
    public class SearchController : Controller
    {
        private readonly IOptions<AppSettingsModel> _appSettings;
        private readonly ILogger<SearchController> _logger;

        private readonly ISearchClient _searchClient;

        public SearchController(ILogger<SearchController> logger, IOptions<AppSettingsModel> app)
        {
            _logger = logger;
            _appSettings = app;
        }

        // GET: Search
        public async Task<ActionResult> Index([FromForm] SearchSettingViewModel searchSettings)
        {
            if (!string.IsNullOrEmpty(searchSettings.SearchEntered))
            {
                var projects = new List<ProjectModel>();
                var users = new List<UserModel>();

                if (searchSettings.TypeSearched=="IsProject")
                {
                    projects = await ApiClientFactory.Instance.GetProjects();
                    var projectsResult = projects.FindAll(p => p.Name.Contains(searchSettings.SearchEntered));
                    projectsResult.AddRange(projects.FindAll(p => p.Description.Contains(searchSettings.SearchEntered)));
                    projectsResult.AddRange(projects.FindAll(p => p.Location.Contains(searchSettings.SearchEntered)));
                    projectsResult.AddRange(projects.FindAll(p => p.ShortDescription.Contains(searchSettings.SearchEntered)));

                    return View($"Projects", projectsResult);
                }

                if (searchSettings.TypeSearched=="IsUser")
                {
                    users = await ApiClientFactory.Instance.GetUsers();
                    var usersResult = users.FindAll(u => u.Name.Contains(searchSettings.SearchEntered));
                    usersResult.AddRange(users.FindAll(u => u.Email.Contains(searchSettings.SearchEntered)));
                    //usersResult.AddRange(users.FindAll(u => u.Bio.Contains(searchSettings.SearchEntered)));

                    return View($"Users", usersResult);
                }
            }

            return View();
        }

        // GET: UsersList
        public ActionResult Users(List<UserModel> usersList)
        {
            return View(usersList);
        }

        // GET: Project
        public async Task<ActionResult> Projects(List<ProjectModel> projectsList)
        {
            return View(projectsList);
        }
    }
}