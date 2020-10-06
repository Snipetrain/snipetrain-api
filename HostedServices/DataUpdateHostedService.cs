using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using snipetrain_api.Hubs;
using snipetrain_api.Models;
using snipetrain_api.Services;

namespace snipetrain_api.HostedServices
{
    public class DataUpdateHostedService : IHostedService, IDisposable
    {
        private readonly ILogger<DataUpdateHostedService> _logger;
        private readonly IConfigurationSection _configSection;
        private readonly IServersService _serversService;
        private readonly IHubContext<ServerInfoHub> _serverInfoHub;
        private Timer _timer;
        private List<Serverinfo> serverInfos = new List<Serverinfo>();
        private int errorCount;

        public DataUpdateHostedService(IHubContext<ServerInfoHub> serverInfoHub, ILogger<DataUpdateHostedService> logger, IConfiguration config, IServersService serversService)
        {
            _logger = logger;
            _configSection = config.GetSection("HostedServices");
            _serversService = serversService;
            _serverInfoHub = serverInfoHub;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Starting Data Update Timer...");
            
            var seconds = _configSection.GetValue<int>("delay");
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(seconds));

            return Task.CompletedTask;
        }

        private async void DoWork(object state)
        {
            try
            {
                await UpdateServerInfo();
            }
            catch (Exception e)
            {
                if (errorCount >= _configSection.GetValue<int>("errorCountLimit"))
                {
                    _logger.LogCritical($"FATAL ERROR in {nameof(DataUpdateHostedService)} :: Error Count Limit Achieved :: Last Exception = {e.ToString()}");
                    await StopAsync(new CancellationToken());
                }
                else
                {
                     errorCount++;
                    _logger.LogWarning($"ERROR in {nameof(DataUpdateHostedService)} :: Error Count = {errorCount} :: Exception = {e.ToString()}");
                }

            }
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Data Update Timer Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }

        private async Task UpdateServerInfo()
        {
            var freshList = await _serversService.GetServerinfosAsync();

            if (serverInfos.Count() < 1)
                serverInfos = freshList;

            foreach (var server in freshList)
            {
                var previous = serverInfos.Find(x => x.Server.Id == server.Server.Id);
                
                if (!server.Server.Equals(previous.Server)) // Check wether any of the servers are different, if so publish new Socket
                {
                    await _serverInfoHub.Clients.All.SendAsync("ServerInfoUpdate", freshList); // Publish socket
                    serverInfos = freshList;
                }
            }
        }
    }
}