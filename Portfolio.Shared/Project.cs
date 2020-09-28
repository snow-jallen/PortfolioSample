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
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [Required]
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("requirements")]
        public string Requirements { get; set; }

        public List<ProjectCategory> ProjectCategories { get; set; }
    }
}
