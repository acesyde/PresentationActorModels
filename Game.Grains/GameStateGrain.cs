using Game.GrainInterfaces.Game;
using Game.GrainInterfaces.Game.Messages;
using Microsoft.Extensions.Logging;
using Orleans;
using Orleans.Streams;
using System;
using System.Threading.Tasks;

namespace Game.Grains
{
    public class GameStateGrain : Grain, IGameState
    {
        private readonly ILogger logger;

        private IAsyncStream<GameMessage> stream;

        public GameStateGrain(ILogger<GameStateGrain> logger)
        {
            this.logger = logger;
        }

        public override Task OnActivateAsync()
        {
            Guid gameId = this.GetPrimaryKey();

            // Get game stream with no namespace for general messages
            IStreamProvider streamProvider = GetStreamProvider("GameStream");
            stream = streamProvider.GetStream<GameMessage>(gameId, "actions");

            return base.OnActivateAsync();
        }
    }
}
