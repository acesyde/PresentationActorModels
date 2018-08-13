using Game.GrainInterfaces.Player;
using Microsoft.Extensions.Logging;
using Orleans;
using System.Threading.Tasks;

namespace Game.Grains
{
    public class PlayerGrain : Grain, IPlayerGrain
    {
        private readonly ILogger logger;

        private PlayerInfo info;

        public PlayerGrain(ILogger<PlayerGrain> logger)
        {
            this.logger = logger;
        }

        public override Task OnActivateAsync()
        {
            info = new PlayerInfo { Key = this.GetPrimaryKeyString(), Name = string.Empty };
            return base.OnActivateAsync();
        }

        public Task SetName(string name)
        {
            info.Name = name;
            logger.LogInformation($"Player {info.Key} set name to {info.Name}");
            return Task.CompletedTask;
        }
    }
}
