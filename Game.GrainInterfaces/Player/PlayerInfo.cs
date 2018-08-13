using Orleans.Concurrency;

namespace Game.GrainInterfaces.Player
{
    [Immutable]
    public class PlayerInfo
    {
        public string Key { get; set; }
        public string Name { get; set; }
    }
}
