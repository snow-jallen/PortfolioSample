using Portfolio.Shared;
using Portfolio.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Api.Data
{
    public interface IRepository
    {
        IQueryable<Project> Projects { get; }
        Task SaveProjectAsync(ProjectViewModel project);
        Task AssignCategoryAsync(AssignRequest assignRequest);
    }
}
