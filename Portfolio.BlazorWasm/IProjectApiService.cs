using Portfolio.Shared;
using Portfolio.Shared.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Portfolio.BlazorWasm
{
    public interface IProjectApiService
    {
        Task AssignAsync(string categoryType, int projectId, string newName);
        Task<ProjectViewModel> GetProjectByIDAsync(int id);
        Task<ProjectViewModel> GetProjectBySlugAsync(string slug);
        Task<IEnumerable<ProjectViewModel>> GetProjectsAsync();
        Task SaveProjectAsync(ProjectViewModel project);
    }
}