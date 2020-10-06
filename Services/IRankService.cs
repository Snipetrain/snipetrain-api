using System.Collections.Generic;
using System.Threading.Tasks;
using snipetrain_api.Models;

namespace snipetrain_api.Services
{
    public interface IRankService
    {
        Task<Pagination<List<Player>>> GetRanks(string game, int page = 1, int perPage = 15);

        Task<Pagination<List<Player>>> GetRanksBySearch(string game, string searchString, int page, int perPage);
    }
}
