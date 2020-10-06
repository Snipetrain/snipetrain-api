using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using snipetrain_api.Models;

namespace snipetrain_api.Hubs
{
    public class ServerInfoHub : Hub
    {
        public async Task ServerInfoUpdated(List<Serverinfo> servers)
        {
            await Clients.All.SendAsync("ServerInfoUpdate", "servers");
        }
    }
}