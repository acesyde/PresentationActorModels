using Game.GrainInterfaces;
using Orleans;
using System.Threading.Tasks;

namespace Game.Grains
{
    public class GameGrain : Grain, IGameGrain
    {
        public Task AddPlayer(IPlayerGrain player)
        {
            var player = new PlayerGrain();
            player.JoinGame(this);
        }
    }
}
