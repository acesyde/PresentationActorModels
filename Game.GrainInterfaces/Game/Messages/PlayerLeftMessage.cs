using Orleans.Concurrency;

namespace Game.GrainInterfaces.Game.Messages
{
    [Immutable]
    public class PlayerLeftMessage : GameMessage
    {
        public string PlayerId { get; set; }
    }
}
