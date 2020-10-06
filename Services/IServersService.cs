using System.Collections.Generic;
using System.Threading.Tasks;
using snipetrain_api.Models;

namespace snipetrain_api.Services
{
    public interface IServersService
    {
        Task<List<ServersSchema>> GetServersAsync();
        Task<Serverinfo> GetServerinfoAsync(string ip, int port);
        Task<List<Serverinfo>> GetServerinfosAsync();
    }
}