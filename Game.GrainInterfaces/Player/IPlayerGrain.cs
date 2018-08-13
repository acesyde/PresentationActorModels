using Orleans;
using System.Threading.Tasks;

namespace Game.GrainInterfaces.Player
{
    public interface IPlayerGrain : IGrainWithStringKey
    {
        Task SetName(string name);
    }
}
