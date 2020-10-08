using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Api.Data;
using Portfolio.Shared;
using Portfolio.Shared.ViewModels;

namespace Portfolio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IRepository repository;

        public ProjectController(IRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet()]
        public async Task<List<ProjectViewModel>> Get()
        {
            return await repository.Projects
                .Include(p=>p.ProjectLanguages)
                    .ThenInclude(pc => pc.Language)
                .Select(p => new ProjectViewModel(p))
                .ToListAsync();
        }

        [HttpGet("[action]")]
        public async Task DefaultData()
        {
            await repository.SaveProjectAsync(new ProjectViewModel
            {
                Title = "Project 1",
                 Requirements = "Demonstrate APIs with a database"
            });


            await repository.SaveProjectAsync(new ProjectViewModel
            {
                Title = "Project 2",
                Requirements = "No, seriously. Do that."
            });
        }

        [HttpPost()]
        public async Task Post(ProjectViewModel project)
        {
            await repository.SaveProjectAsync(project);
        }

        [HttpGet("{id:int}")]
        public async Task<ProjectViewModel> GetProject(int id)
        {
            var project = await repository.Projects
               .Include(p => p.ProjectLanguages)
                   .ThenInclude(pc => pc.Language)
                .FirstOrDefaultAsync(p => p.Id == id);


            return new ProjectViewModel(project);
        }

        [HttpGet("{slug}")]
        public async Task<ProjectViewModel> GetProject(string slug)
        {
            try
            {
                var project = await repository.Projects
                   .Include(p => p.ProjectLanguages)
                       .ThenInclude(pc => pc.Language)
                    .FirstOrDefaultAsync(p => p.Slug == slug);
                return new ProjectViewModel(project);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

       [HttpPost("[action]")]
       public async Task Assign(AssignRequest assignRequest)
        {
            await repository.AssignCategoryAsync(assignRequest);
        }
    }
}
