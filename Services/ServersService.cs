using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using RestSharp;
using RestSharp.Serialization.Xml;
using snipetrain_api.Models;

namespace snipetrain_api.Services
{
    public class ServersService : IServersService
    {
        private readonly RestClient _client;
        private readonly IMongoCollection<ServersSchema> _servers;
        public ServersService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("snipetrain"));
            var database = client.GetDatabase("snipetrain");

            _servers = database.GetCollection<ServersSchema>("sn_servers");

            _client = new RestClient(config.GetSection("Endpoints").GetValue<string>("GameMe"));
            _client.UseDotNetXmlSerializer();
        }
        public async Task<List<ServersSchema>> GetServersAsync()
        {
            return (await _servers.FindAsync(s => true)).ToList();
        }

        public async Task<Serverinfo> GetServerinfoAsync(string ip, int port)
        {
            var request = new RestRequest($"serverinfo/{ip}:{port}/players");
            var res = await _client.GetAsync<PlayerInfoGameMe>(request);
            return res.Serverinfo;
        }

        public async Task<List<Serverinfo>> GetServerinfosAsync()
        {
            var servers =  await GetServersAsync();
            
            List<Serverinfo> serverinfos = new List<Serverinfo>();

            foreach (var server in servers)
            {
                foreach (var srcdServer in server.SrcdServers)
                {
                    serverinfos.Add(await GetServerinfoAsync(server.IpAddress, srcdServer.Port));
                }
            }

            return serverinfos;
        }
    }
}
