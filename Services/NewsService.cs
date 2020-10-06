using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using snipetrain_api.Models;

namespace snipetrain_api.Services
{
    public class NewsService : INewsService
    {
        private readonly IMongoCollection<NewsSchema> _news;
        public NewsService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("snipetrain"));
            var database = client.GetDatabase("snipetrain");

            _news = database.GetCollection<NewsSchema>("sn_news");
        }
        public async Task<List<NewsSchema>> GetNewsAsync()
        {
            return (await _news.FindAsync(s => true)).ToList();
        }
    }
}
