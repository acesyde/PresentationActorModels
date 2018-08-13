using Orleans;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Game.GrainInterfaces.Game
{
    public interface IGameManagerGrain : IGrainWithStringKey
    {
        Task<Guid> CreateGame();
        Task<List<Guid>> ListGames();
    }
}
