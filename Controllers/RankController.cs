using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using snipetrain_api.Exceptions;
using snipetrain_api.Services;
//using snipetrain-api.Models;

namespace snipetrain_api.Controllers
{
    [Route("api/ranks")]
    [ApiController]
    public class RankController : ControllerBase
    {
        private readonly ILogger<RankController> _logger;
        private readonly IRankService _rankService;
        public RankController(IRankService rankService, ILogger<RankController> logger)
        {
            _rankService = rankService;
            _logger = logger;
        }


        [HttpGet("{game}")]
        public async Task<IActionResult> GetGameRanks(string game, int page = 1, int perPage = 15)
        {
            try
            {
                if (String.IsNullOrEmpty(game))
                    return BadRequest("Invalid request.");

                var pagedRes = await _rankService.GetRanks(game, page, perPage);

                return Ok(pagedRes);
            }
            catch (Exception e)
            {
                _logger.LogError($"Unexpected error in {nameof(RankController)} :: {e.ToString()}");
                return StatusCode(500, "Unexpected Error :: Please have admin check logs.");
            }
        }

        [HttpGet("{game}/{searchString}")]
        public async Task<IActionResult> GetGameRanksBySearch(string game, string searchString, int page = 1, int perPage = 15)
        {
            try
            {
                if (String.IsNullOrEmpty(game) || String.IsNullOrEmpty(searchString))
                    return BadRequest("Invalid request.");

                var pagedRes = await _rankService.GetRanksBySearch(game, searchString, page, perPage);

                return Ok(pagedRes);
            }
            catch (PlayerNotFoundException e)
            {
                _logger.LogWarning($"Player not found with searchString=\"{searchString}\".");
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                _logger.LogError($"Unexpected error in {nameof(RankController)} :: {e.ToString()}");
                return StatusCode(500, "Unexpected Error :: Please have admin check logs.");
            }
        }

    }
}