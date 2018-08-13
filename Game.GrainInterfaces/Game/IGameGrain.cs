using Game.GrainInterfaces.Game.Messages;
using Game.GrainInterfaces.Player;
using Orleans;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Game.GrainInterfaces.Game
{
    public interface IGameGrain : IGrainWithGuidKey
    {
        Task Join(IPlayerGrain player);

        Task Leave(IPlayerGrain player);

        Task ProcessActionMessage(IPlayerGrain player, GameMessage message);

        Task<List<IPlayerGrain>> ListPlayers();
    }
}
