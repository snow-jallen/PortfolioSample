using Portfolio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace Portfolio.BlazorWasm
{
    public class ProjectApiService
    {
        private readonly HttpClient client;

        public ProjectApiService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<IEnumerable<Project>> GetProjectsAsync()
        {
            var response = await client.GetAsync("api/project");
            return await client.GetFromJsonAsync<IEnumerable<Project>>("api/project");
        }

        public async Task SaveProjectAsync(Project project)
        {
            await client.PostAsJsonAsync("api/project", project);
        }

        public async Task<Project> GetProjectByIDAsync(int id)
        {
            return await client.GetFromJsonAsync<Project>($"api/project/{id}");
        }

        public async Task AssignAsync(string categoryType, int projectId, string newName)
        {
            var assignBody = new AssignRequest
            {
                CategoryType = categoryType,
                Name = newName,
                ProjectId = projectId
            };
            await client.PostAsJsonAsync($"api/project/assign/", assignBody);
        }
    }
}
