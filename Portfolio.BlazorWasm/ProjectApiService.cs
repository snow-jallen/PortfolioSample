using static System.Diagnostics.Debug;
using Portfolio.Shared;
using Portfolio.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System.Net.Http.Headers;

namespace Portfolio.BlazorWasm
{
    public class ProjectApiService : IProjectApiService
    {
        private readonly HttpClient client;
        private readonly IAccessTokenProvider tokenProvider;

        public ProjectApiService(HttpClient client, IAccessTokenProvider tokenProvider)
        {
            this.client = client;
            this.tokenProvider = tokenProvider;
        }

        public async Task<IEnumerable<ProjectViewModel>> GetProjectsAsync()
        {
            return await client.GetFromJsonAsync<IEnumerable<ProjectViewModel>>("api/project");
        }

        public async Task SaveProjectAsync(ProjectViewModel project)
        {
            await client.PostAsJsonAsync("api/project", project);
        }

        public async Task<ProjectViewModel> GetProjectByIDAsync(int id)
        {
            return await client.GetFromJsonAsync<ProjectViewModel>($"api/project/{id}");
        }

        public async Task<ProjectViewModel> GetProjectBySlugAsync(string slug)
        {
            return await client.GetFromJsonAsync<ProjectViewModel>($"api/project/{slug}");
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
