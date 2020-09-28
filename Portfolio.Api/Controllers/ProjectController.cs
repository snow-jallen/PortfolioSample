﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Api.Data;
using Portfolio.Shared;

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
        public async Task<List<Project>> Get() => await repository.Projects.ToListAsync();

        [HttpGet("[action]")]
        public async Task DefaultData()
        {
            await repository.SaveProjectAsync(new Project
            {
                Title = "Project 1",
                 Requirements = "Demonstrate APIs with a database"
            });


            await repository.SaveProjectAsync(new Project
            {
                Title = "Project 2",
                Requirements = "No, seriously. Do that."
            });
        }

        [HttpPost()]
        public async Task Post(Project project)
        {
            await repository.SaveProjectAsync(project);
        }

        [HttpGet("projectdetails/{id}")]
        public string Details(int id)
        {
            return $"You asked for details of {id}";
        }

        [HttpGet("[action]/{id}")]
        public string ProjDetails(int id)
        {
            return $"You asked for details of {id}";
        }
    }
}