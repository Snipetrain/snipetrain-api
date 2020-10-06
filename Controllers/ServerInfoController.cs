using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using snipetrain_api.Models;
using snipetrain_api.Services;
//using snipetrain-api.Models;

namespace snipetrain_api.Controllers
{
    [EnableCors("Cors-Policy")]
    [Route("api/serverinfo")]
    [ApiController]
    public class ServerInfoController : ControllerBase
    {
        private readonly ILogger<ServerInfoController> _logger;
        private readonly IServersService _serversService;

        public ServerInfoController(IServersService serversService, ILogger<ServerInfoController> logger)
        {
            _logger = logger;
            _serversService = serversService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Serverinfo>>> GetServerInfo()
        {
            try
            {
                return Ok(await _serversService.GetServerinfosAsync());
            }
            catch (Exception e)
            {
                _logger.LogError($"Unexpected error in {nameof(ServerInfoController)} : {e.ToString()}", e);
                return StatusCode(500, "Unexpected Error :: Please have admin check logs.");
            }
        }
    }
}