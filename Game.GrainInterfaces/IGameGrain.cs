using Orleans;
using System.Threading.Tasks;

namespace Game.GrainInterfaces
{
    public interface IGameGrain : IGrainWithGuidKey
    {
        Task AddPlayer(IPlayerGrain player);
    }
}
