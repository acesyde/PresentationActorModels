using Game.GrainInterfaces.Game.Messages;
using Orleans;
using System.Threading.Tasks;

namespace Game.GrainInterfaces.Game
{
    public interface IGameActionMessageHandler : IGrainWithGuidKey
    {
        Task ProcessMessage(GameMessage message);
    }
}
