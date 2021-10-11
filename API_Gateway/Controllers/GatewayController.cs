﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace API_Gateway.Controllers
{
    [Route("[action]")]
    [ApiController]
    public class ProxyController : ControllerBase
    {
        // The first line of code below this line

        private readonly HttpClient _httpClient;
        public ProxyController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }
        [HttpGet]
        public async Task<IActionResult> Books()
        {
            return await ProxyTo("https://localhost:44366/books");
        }

        [HttpGet]
        public async Task<IActionResult> Authors()
        {
            await ProxyTo("https://localhost:44367/authors");
        }

        private async Task<ContentResult> ProxyTo(string url)
        {
            return Content(await _httpClient.GetStringAsync(url));
        }



        // the last line of code above this line
    }
}
