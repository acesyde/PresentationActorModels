using Game.GrainInterfaces;
using Game.GrainInterfaces.Game;
using Microsoft.Extensions.Logging;
using Orleans;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Game.Grains
{
    public class GameManagerGrain : Grain, IGameManagerGrain
    {
        private readonly ILogger<GameManagerGrain> logger;
        private readonly IGrainFactory grainFactory;
        private HashSet<IGameGrain> games = new HashSet<IGameGrain>();

        public GameManagerGrain(ILogger<GameManagerGrain> logger, IGrainFactory grainFactory)
        {
            this.logger = logger;
            this.grainFactory = grainFactory;
        }

        public override Task OnActivateAsync()
        {
            return base.OnActivateAsync();
        }

        public Task<Guid> CreateGame()
        {

            throw new NotImplementedException();
        }

        public Task<List<Guid>> ListGames()
        {
            return Task.FromResult(new List<Guid>());
        }
    }
}
