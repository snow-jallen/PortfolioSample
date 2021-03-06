﻿using Portfolio.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Portfolio.Shared
{
    public class Project
    {
        public Project()
        {

        }

        public Project(ProjectViewModel vm)
        {
            this.Id = vm.Id;
            this.Title = vm.Title;
            this.Requirements = vm.Requirements;
            this.Slug = vm.Slug;
        }

        public const string LanguageCategory = "language";
        public const string PlatformCategory = "platform";
        public const string TechnologyCategory = "technology";

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [Required]
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("requirements")]
        public string Requirements { get; set; }

        public List<ProjectLanguage> ProjectLanguages { get; set; }

        public string Slug { get; set; }
    }
}
