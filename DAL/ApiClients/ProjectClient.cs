using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasefugeesWebApp.DAL.DTO;

namespace BasefugeesWebApp.DAL.ApiClients
{
    public partial class ApiClient
    {
        public async Task<List<ProjectModel>> GetProjects()
        {
            return await GetAsync<List<ProjectModel>>("/projects");
        }

        public async Task<ProjectModel> GetProject(string projectName)
        {
            return await GetAsync<ProjectModel>("/projects/" + projectName);
        }

        public async Task<ProjectModel> CreateProject(ProjectModel model)
        {
            return await PostAsync<ProjectModel>("/createproject", model);
        }

        public async Task<ProjectModel> EditProject(string projectId, ProjectModel model)
        {
            return await PatchAsync<ProjectModel>("/projects/updateProject/" + projectId, model);
        }
    }
}
