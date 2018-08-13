using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Orleans;
using Orleans.Configuration;
using Orleans.Hosting;

namespace HomeAutomation.Api
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
            services.AddMvc();
            
            services
                .AddDbContext<Game.Api.Data.GameDbContext>(builder => builder.UseMySQL("server=mysql;database=game;user=orleans;password=eQLcnkkprV7PbX"));

            services.AddSingleton<IClusterClient>(CreateOrleansClient());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }

        private IClusterClient CreateOrleansClient()
        {
            var clientBuilder = new ClientBuilder()
                .Configure<ClusterOptions>(options =>
                {
                    options.ClusterId = "dev";
                    options.ServiceId = "game";
                })
                .UseZooKeeperClustering((ZooKeeperGatewayListProviderOptions options) =>
                {
                    options.ConnectionString = "zookeeper";
                })
                .ConfigureLogging(logging => logging.AddConsole());

            var client = clientBuilder.Build();

            client.Connect(async ex =>
            {
                Console.WriteLine("Retrying...");
                await Task.Delay(3000);
                return true;
            }).Wait();

            return client;
        }
    }
}
