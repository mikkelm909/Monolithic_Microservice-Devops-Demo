﻿using AuthorsService.Data;
using AuthorsService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorsService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorsController : Controller
    {
        private readonly ILogger<AuthorsController> _logger;
        private readonly Repository _repository;

        public AuthorsController(ILogger<AuthorsController> logger, Repository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<Author> Get() => _repository.GetAuthors();
    }
}
