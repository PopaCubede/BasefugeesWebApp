using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasefugeesWebApp.DAL.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BasefugeesWebApp.ViewModels.Components
{
    [ViewComponent(Name = "Card")]
    public class CardViewComponent : ViewComponent
    {
        private readonly List<ProjectModel> projects;

        public CardViewComponent(List<ProjectModel> context)
        {
            projects = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(
            int qtyCards, bool isFeatured)
        {
            var items = await GetFeaturedProjectsAsync(qtyCards, isFeatured);
            return View(items);
        }
        private async Task<List<ProjectModel>> GetFeaturedProjectsAsync(int qtyCards, bool isFeatured)
        {
            var displayedProjects = new List<ProjectModel>();
            var featuredProjects = projects.Where(x => x.Featured == isFeatured).ToList();

            displayedProjects.Add(featuredProjects[0]);
            displayedProjects.Add(featuredProjects[1]);
            displayedProjects.Add(featuredProjects[2]);

            return displayedProjects;
        }
    }
}
