using System.Collections.Generic;
using System.Threading.Tasks;
using snipetrain_api.Models;

namespace snipetrain_api.Services
{
    public interface INewsService
    {
        Task<List<NewsSchema>> GetNewsAsync();
    }
}