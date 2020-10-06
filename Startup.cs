using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using snipetrain_api.HostedServices;
using snipetrain_api.Hubs;
using snipetrain_api.Services;

namespace snipetrain_api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSignalR();

            services.AddScoped<INewsService, NewsService>();
            services.AddScoped<IRankService, RankService>();
            services.AddTransient<IServersService, ServersService>();

            services.AddHostedService<DataUpdateHostedService>();

            services.AddCors(options =>
            {
                options.AddPolicy("Cors-Policy",
                builder =>
                {
                    builder.WithOrigins(Configuration.GetSection("Cors").GetSection("allowedOrigins").GetChildren().ToArray().Select(c => c.Value).ToArray());
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // Proxy stuff
                app.UseHsts();
                app.UseForwardedHeaders(new ForwardedHeadersOptions
                {
                    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("Cors-Policy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<ServerInfoHub>("serverinfohub");
            });
        }
    }
}
