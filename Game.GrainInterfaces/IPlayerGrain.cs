using Orleans;
using System.Threading.Tasks;

namespace Game.GrainInterfaces
{
    public interface IPlayerGrain : IGrainWithStringKey
    {
        Task<IGameGrain> GetCurrentGame();
        Task JoinGame(IGameGrain game);
        Task LeaveGame(IGameGrain game);
    }
}
