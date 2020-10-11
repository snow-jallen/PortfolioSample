using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;

namespace Portfolio.Shared.ViewModels
{
    public class ProjectViewModel
    {
        public ProjectViewModel()
        {
            Languages = new List<LanguageViewModel>();
        }

        public ProjectViewModel(Project p)
        {
            Id = p.Id;
            Title = p.Title;
            Requirements = p.Requirements;
            Languages = new List<LanguageViewModel>(p.ProjectLanguages.Select(pl => new LanguageViewModel(pl.Language)));
            Slug = p.Slug;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Requirements { get; set; }
        public IList<LanguageViewModel> Languages { get; set; }
        public string Slug { get; set; }
    }
}
