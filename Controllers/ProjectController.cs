using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasefugeesWebApp.DAL.ApiClients;
using BasefugeesWebApp.DAL.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasefugeesWebApp.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        public async Task<ActionResult> Index()
        {
            var projects = await ApiClientFactory.Instance.GetProjects();
            return View(projects);
        }

        // GET: Project/Details/5
        public async Task<ActionResult> Details(string name)
        {
            var project = await ApiClientFactory.Instance.GetProject(name);
            return View(project);
        }

        // GET: Project/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Project/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([FromForm] ProjectModel formObj)
        {
            try
            {
                // TODO: Add insert logic here
                var result = await ApiClientFactory.Instance.CreateProject(formObj);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Project/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Project/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Project/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Project/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}