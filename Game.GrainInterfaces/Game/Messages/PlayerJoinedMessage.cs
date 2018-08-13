using Orleans.Concurrency;

namespace Game.GrainInterfaces.Game.Messages
{
    [Immutable]
    public class PlayerJoinedMessage : GameMessage
    {
        public string PlayerId { get; set; }
    }
}
