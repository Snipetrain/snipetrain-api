using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using snipetrain_api.Models;
using snipetrain_api.Services;

namespace snipetrain_api.Controllers
{
    [EnableCors("Cors-Policy")]
    [Route("api/news")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly ILogger<NewsController> _logger;
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService, ILogger<NewsController> logger)
        {
            _logger = logger;
            _newsService = newsService;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<NewsSchema>>> GetNewsAsync()
        {
            try
            {
                return Ok(await _newsService.GetNewsAsync());
            }
            catch (Exception e)
            {
                _logger.LogError($"Unexpected error in {nameof(NewsController)} :: {e.ToString()}");
                return StatusCode(500, "Unexpected Error :: Please have admin check logs.");
            }
        }
    }
}