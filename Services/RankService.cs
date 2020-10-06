
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using RestSharp;
using RestSharp.Serialization.Xml;
using snipetrain_api.Exceptions;
using snipetrain_api.Models;

namespace snipetrain_api.Services 
{
    public class RankService : IRankService
    {
        private readonly RestClient _client;
        
        public RankService(IConfiguration config)
        {
            _client = new RestClient(config.GetSection("Endpoints").GetValue<string>("GameMe"));
            _client.UseDotNetXmlSerializer();
        }

        public async Task<Pagination<List<Player>>> GetRanks(string game, int page, int perPage)
        {
            var request = new RestRequest($"playerlist/{game}/?limit={perPage}&page={page}");
            var res = await _client.GetAsync<PlayerGameME>(request);

            return new Pagination<List<Player>>() {
                PerPage = int.Parse(res.Playerlist.Pagination.Pageentries),
                TotalItems = int.Parse(res.Playerlist.Pagination.Totalcount),
                TotalPages = int.Parse(res.Playerlist.Pagination.Totalpages),
                PageIndex = int.Parse(res.Playerlist.Pagination.Currentpage),
                Payload = res.Playerlist.Player
            };
        }
        
        public async Task<Pagination<List<Player>>> GetRanksBySearch(string game, string searchString, int page, int perPage)
        {
            var nameRequest = new RestRequest($"playerlist/{game}/name/{searchString}?limit={perPage}&page={page}");
            var nameRes = await _client.GetAsync<PlayerGameME>(nameRequest);

            Playerlist result;
            
            if (nameRes.Playerlist.Player.Count() > 0) // Only send 2nd request if needed
            {
                result = nameRes.Playerlist;
            }
            else
            {
                var idRequest = new RestRequest($"playerlist/{game}/uniqueid/{searchString}?limit={perPage}&page={page}");
                var idRes = await _client.GetAsync<PlayerGameME>(idRequest);
                result = idRes.Playerlist;
            }

            if (result.Player.Count < 1)
                throw new PlayerNotFoundException("No results found.");

            return new Pagination<List<Player>>() {
                PerPage = int.Parse(result.Pagination.Pageentries),
                TotalItems = int.Parse(result.Pagination.Totalcount),
                TotalPages = int.Parse(result.Pagination.Totalpages),
                PageIndex = int.Parse(result.Pagination.Currentpage),
                Payload = result.Player
            };
        }

    }
}