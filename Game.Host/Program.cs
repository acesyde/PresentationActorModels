using Game.Grains;
using Microsoft.Extensions.Logging;
using Orleans;
using Orleans.Configuration;
using Orleans.Hosting;
using System;
using System.Threading.Tasks;

namespace HomeAutomation.Host
{
    class Program
    {
        public static int Main(string[] args)
        {
            return RunMainAsync().Result;
        }

        private static async Task<int> RunMainAsync()
        {
            try
            {
                var host = await StartSilo();
                Console.WriteLine("Press Enter to terminate...");
                Console.ReadLine();

                await host.StopAsync();

                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return 1;
            }
        }

        private static async Task<ISiloHost> StartSilo()
        {
            // define the cluster configuration
            var builder = new SiloHostBuilder()
                .Configure<ClusterOptions>(options =>
                {
                    options.ClusterId = "dev";
                    options.ServiceId = "game";
                })
                .UseZooKeeperClustering((ZooKeeperClusteringSiloOptions options) =>
                {
                    options.ConnectionString = "zookeeper";
                })
                .ConfigureEndpoints(11111, 25000)
                .ConfigureApplicationParts(parts => parts.AddApplicationPart(typeof(PlayerGrain).Assembly).WithReferences())
                .ConfigureLogging(logging => logging.AddConsole())
                .AddMemoryGrainStorage("PubSubStore")
                .AddSimpleMessageStreamProvider("GameStream");

            var host = builder.Build();
            await host.StartAsync();
            return host;
        }
    }
}
