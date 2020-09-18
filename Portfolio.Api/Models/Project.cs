using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Api.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Requirements { get; set; }
    }
}
